﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DecisionAlgorithm
{
    class Prediction
    {
        [ColumnName("PredictedLabel"), LoadColumn(5)]
        public bool Validation { get; set; }
    }
}
