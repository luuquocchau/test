using MediatR;

namespace HRM.Application.Abstractions.CQRS;

public interface IQuery<TResponse> : IRequest<TResponse>;
