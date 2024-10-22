using Common.Core.Queries;

namespace HomeWork.Features.GetGrade
{
    public record GetGradeResponse(Guid Id, string Name, decimal FixedAmount);
    public class GetGradeQueryHandler(IDocumentSession documentSession) : IQueryHandler<GetGradeQuery, GetGradeResponse>
    {
        public async Task<GetGradeResponse> Handle(GetGradeQuery request, CancellationToken cancellationToken)
        {
            var response = await documentSession.LoadAsync<Models.Grade.Grade>(request.Id, cancellationToken);
            if (response is null)
                throw new Exception("Not found");
            else
                return new GetGradeResponse(response.Id, response.Name, response.FixedAmount);
        }
    }
}
