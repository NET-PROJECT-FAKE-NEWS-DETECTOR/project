using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateDataSetCommandHandler : IRequestHandler<CreateDataSetCommand, Guid>
    {
        private readonly IDataSetRepository repository;

        public CreateDataSetCommandHandler(IDataSetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(CreateDataSetCommand request, CancellationToken cancellationToken)
        {
            var dataSet = new DataSet
            {
                Title = request.Title,
                Text = request.Text,
                Subject = request.Subject,
                Date = request.Date,
                Validation = request.Validation
            };

            await repository.AddAsync(dataSet);
            return dataSet.Id;
        }
    }
}
