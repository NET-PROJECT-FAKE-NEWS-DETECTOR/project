using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteDataSetCommandHandler : IRequestHandler<DeleteDataSetCommand, Guid>
    {
        private readonly IDataSetRepository repository;

        public DeleteDataSetCommandHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(DeleteDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSet = repository.GetByIdAsync(request.Id).Result;
            if (dataSet == null || dataSet.Id == Guid.Empty)
            {
                throw new Exception("Data doesn't exist!");
            }

            await repository.DeleteAsync(dataSet);

            return dataSet.Id;
        }
    }
}
