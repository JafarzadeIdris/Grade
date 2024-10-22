namespace HomeWork.Features.Grade
{
    public record GradeCreateRequest(string Name, decimal FixedAmount);

    public class CreateGradeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/grades", async (GradeCreateRequest createRequest, ISender sender) =>
            {
                GradeCreateCommand command = createRequest.Adapt<GradeCreateCommand>();
                var response = await sender.Send(command);
                return Results.Created($"/grades/{response.Id}", response);
            });
        }
    }
}
