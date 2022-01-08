using Microsoft.ML;
using Microsoft.ML.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Application.Features.DecisionAlgorithm
{
    public class NewsPrediction
    {

        private static bool FirstTime { get; set; } = true;
        private static PredictionEngine<ModelInput, Prediction> PredictionFunc { get; set; }

        public static async void Train()
        {
            var loaderColumns = new DatabaseLoader.Column[]
         {
                new DatabaseLoader.Column() {Name = "Title", Type = DbType.String },
                new DatabaseLoader.Column() {Name = "Text", Type = DbType.String },
                new DatabaseLoader.Column() {Name = "Subject", Type = DbType.String },
                new DatabaseLoader.Column() {Name = "Validation", Type = DbType.Boolean }
         };

            var connectionString = "server=localhost;database=dotnetproject;user=root;password=acasa213";

            using var connection = new MySqlConnection(connectionString);


            await connection.OpenAsync();


            var factory = DbProviderFactories.GetFactory(connection);

            var context = new MLContext();

            var loader = context.Data.CreateDatabaseLoader(loaderColumns);

            var dbSource = new DatabaseSource(factory, connectionString,
                "SELECT * FROM datasets;");


            var data = loader.Load(dbSource);


            var testTrainSplit = context.Data.TrainTestSplit(data, testFraction: 0.1);

            var features = data.Schema
                   .Select(col => col.Name)
                   .Where(colName => colName != "Title" && colName != "Validation").ToArray();


            var pipeline = context.Transforms.Text.FeaturizeText("Title")
                .Append(context.Transforms.Text.FeaturizeText("Text"))
                .Append(context.Transforms.Text.FeaturizeText("Subject"))
                .Append(context.Transforms.Concatenate("Features", new[] { "Title", "Text", "Subject" }))
                .Append(context.BinaryClassification.Trainers.AveragedPerceptron(featureColumnName: "Features", labelColumnName: "Validation"));
              

            var model = pipeline.Fit(testTrainSplit.TestSet);

            IDataView transformedData = model.Transform(data);

            PredictionFunc = context.Model.CreatePredictionEngine<ModelInput, Prediction>(model);
        }

        public static bool Predict(string title, string text, string subject)
        {
            if (FirstTime == true)
            {
                FirstTime = false;
                Train();
            }


            var prediction = PredictionFunc.Predict(new ModelInput
            {
                Title = title,
                Text = text,
                Subject = subject
            });

            return prediction.Validation;

        }

    }
}

