using MediatR;

namespace HRM.Application.Abstractions.CQRS;

public interface ICommand : IRequest, IBaseCommand;

public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand;

public interface IBaseCommand;
