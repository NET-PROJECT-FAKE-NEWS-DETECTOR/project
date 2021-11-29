using Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    class UpdateDataSetCommandHandler : IRequestHandler<UpdateDataSetCommand, Guid>
    {
        private readonly IDataSetRepository repository;

        public UpdateDataSetCommandHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(UpdateDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSet = repository.GetByIdAsync(request.Id).Result;
            if (dataSet == null || dataSet.Id == Guid.Empty)
            {
                throw new ArgumentNullException("Data doesn't exist!");
            }

            dataSet.Title = request.Title;
            dataSet.Text = request.Text;
            dataSet.Subject = request.Subject;
            dataSet.Date = request.Date;
            dataSet.Validation = request.Validation;

            await repository.UpdateAsync(dataSet);

            return dataSet.Id;

        }
    }
}

