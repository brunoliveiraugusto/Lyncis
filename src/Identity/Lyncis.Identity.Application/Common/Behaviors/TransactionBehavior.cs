using Lyncis.Identity.Application.Common.Interfaces;
using MediatR;

namespace Lyncis.Identity.Application.Common.Behaviors
{
    internal class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionBehavior(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            await _unitOfWork.BeginTransactionAsync(ct);

            try
            {
                var response = await next();
                
                await _unitOfWork.SaveChangesAsync(ct);
                await _unitOfWork.CommitTransactionAsync(ct);

                return response;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(ct);

                throw;
            }
        }
    }
}
