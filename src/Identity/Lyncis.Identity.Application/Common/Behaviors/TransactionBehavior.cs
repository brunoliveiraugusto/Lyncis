using Lyncis.Identity.Application.Common.Interfaces;
using MediatR;

namespace Lyncis.Identity.Application.Common.Behaviors
{
    internal class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _uow;

        public TransactionBehavior(IUnitOfWork uow) => _uow = uow;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            await _uow.BeginTransactionAsync(ct);

            try
            {
                var response = await next();
                
                await _uow.SaveChangesAsync(ct);
                await _uow.CommitTransactionAsync(ct);

                return response;
            }
            catch (Exception)
            {
                await _uow.RollbackTransactionAsync(ct);

                throw;
            }
        }
    }
}
