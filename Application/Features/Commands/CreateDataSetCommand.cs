using MediatR;
using System;

namespace Application.Features.Commands
{
    public class CreateDataSetCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool Validation { get; set; }
    }
}
