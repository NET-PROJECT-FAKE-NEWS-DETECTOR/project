using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DecisionAlgorithm
{
    public class ModelInput
    {
        [LoadColumn(1)]
        public string Title { get; set; }

        [LoadColumn(2)]
        public string Text { get; set; }

        [ LoadColumn(3)]
        public string Subject { get; set; }

        [ColumnName("Validation"), LoadColumn(5)]
        public bool Validation { get; set; }


    }
}
