using Common.Core.Commands;

namespace HomeWork.Features.UpdateGrade
{
    public record UpdateGradeCommand(Models.Grade.Grade Grade) : ICommand<UpdateGradeResponse>;
    public record UpdateGradeResponse(Models.Grade.Grade Grade);
    public class UpdateGradeCommandHandler : ICommandHandler<UpdateGradeCommand, UpdateGradeResponse>
    {
        private readonly IDocumentSession _documentSession;

        public UpdateGradeCommandHandler(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }

        public async Task<UpdateGradeResponse> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            var existingGrade = await _documentSession.LoadAsync<Models.Grade.Grade>(request.Grade.Id, cancellationToken);

            request.Grade.Adapt(existingGrade);
            _documentSession.Store(existingGrade);
            await _documentSession.SaveChangesAsync(cancellationToken);

            UpdateGradeResponse updateGrade = new(request.Grade);
            return updateGrade;
        }
    }
}
