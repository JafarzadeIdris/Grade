
namespace HomeWork.Features.GetGrades
{
    public class GetGradesEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/grades", async (ISender send) =>
            {
                var response = await send.Send(new GetGradesQuery());
                return Results.Ok(response);
            });
        }
    }
}
