using Common.Core.Commands;

namespace HomeWork.Features.DeleteGrade
{
    public record DeleteGradeRequest(Guid id) : ICommand<DeleteGradeResponse>;
    public record DeleteGradeResponse();
    public class DeleteGradeCommandHandler(IDocumentSession documentSession) : ICommandHandler<DeleteGradeRequest, DeleteGradeResponse>
    {

        public async Task<DeleteGradeResponse> Handle(DeleteGradeRequest request, CancellationToken cancellationToken)
        {
            var existGrade = await documentSession.LoadAsync<Models.Grade.Grade>(request.id, cancellationToken);

            if (existGrade is null)
                throw new ArgumentNullException(nameof(existGrade));

            documentSession.Delete(existGrade!);
            await documentSession.SaveChangesAsync(cancellationToken);
            return new DeleteGradeResponse();

        }
    }
}
