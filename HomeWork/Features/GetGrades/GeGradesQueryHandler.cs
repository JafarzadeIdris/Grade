using Common.Core.Queries;
using System.Linq;

namespace HomeWork.Features.GetGrades
{
    public record GetGradesResponse(IEnumerable<Models.Grade.Grade> Grades);
    public record GetGradesQuery() : IQuery<GetGradesResponse>;
    public class GeGradesQueryHandler(IDocumentSession documentSession) : IQueryHandler<GetGradesQuery, GetGradesResponse>
    {
        public async Task<GetGradesResponse> Handle(GetGradesQuery request, CancellationToken cancellationToken)
        {
            var response = await documentSession.Query<Models.Grade.Grade>().ToListAsync(cancellationToken);
            return new GetGradesResponse(response);
        }
    }
}
