
namespace HomeWork.Features.UpdateGrade
{
    public class UpdateGradeEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/updateGrade", async (UpdateGradeCommand updateGrade, ISender sender) =>
            {
                var response = await sender.Send(updateGrade);
                return Results.Ok(response);
            });
        }
    }
}
