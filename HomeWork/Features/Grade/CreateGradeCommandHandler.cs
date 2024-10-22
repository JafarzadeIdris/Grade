namespace HomeWork.Features.Grade;

public record GradeCreateCommand(string Name, decimal FixedAmount) : ICommand<GradeCreateResponse> { }
public record GradeCreateResponse(Guid Id);

public class GradeCreateCommandValidator : AbstractValidator<GradeCreateCommand>
{
    public GradeCreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().Length(5).WithMessage("Name is required");
        RuleFor(x => x.FixedAmount).NotNull().NotEmpty().WithMessage("Fixed Amount is required");
    }
}

public class CreateGradeCommandHandler : ICommandHandler<GradeCreateCommand, GradeCreateResponse>
{
    private readonly IDocumentSession _session;
    public CreateGradeCommandHandler(IDocumentSession session)
    {
        _session = session;
    }
    public async Task<GradeCreateResponse> Handle(GradeCreateCommand request, CancellationToken cancellationToken)
    {

        Models.Grade.Grade grade = new Models.Grade.Grade()
        {
            FixedAmount = request.FixedAmount,
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        _session.Store(grade);
        await _session.SaveChangesAsync(cancellationToken);
        return new GradeCreateResponse(grade.Id);
    }
}
