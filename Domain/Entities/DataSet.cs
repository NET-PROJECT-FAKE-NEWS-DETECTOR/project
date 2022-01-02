using Domain.Common;
using System;

namespace Domain.Entities
{
    public class DataSet : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public bool Validation { get; set; }
    }
}
