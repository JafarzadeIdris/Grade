using Common.Core.Queries;

namespace HomeWork.Features.GetGrade
{
    public record GetGradeQuery(Guid Id):IQuery<GetGradeResponse>;
    public class GetGradeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/grades/{id}", async (Guid id, ISender sender) =>
            {
                var response = await sender.Send(new GetGradeQuery(id));
                return Results.Ok(response);
            });
        }
    }
}
