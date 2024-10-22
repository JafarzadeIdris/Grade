
namespace HomeWork.Features.DeleteGrade
{
    public class DeleteGradeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/deleteGrade", async (DeleteGradeRequest request, ISender sender) =>
            {
                var response = await sender.Send(request);
                return Results.Ok(response);
            });
        }
    }
}
