using MediatR;

namespace Common.Core.Commands;
public interface ICommand<out TResponse> : IRequest<TResponse> { }
public interface ICommand : IRequest<Unit> { }
