using Application.Features.DecisionAlgorithm;
using FluentAssertions;
using Xunit;

namespace ApplicationTest.Features.Prediction
{
    public class PredictTest
    {
        [Fact]
        public void Given_TrueNews_When_PredictIsCalled_Then_ShouldReturnTrue()
        {
            //Arrange
            string title = "Scientists decry Arctic oil expansion in letter to U.S. senators";
            string text = "NEW YORK (Reuters) - A group of 37 U.S.-based scientists whose research focuses on Arctic wildlife asked two U.S. senators in a letter on Thursday";
            string subject = "politicsNews";

            //Act
            bool result = NewsPrediction.Predict(title, text, subject);
          
            //Assert
            result.Should().BeTrue();


        }

        [Fact]
        public void Given_FakeNews_When_PredictIsCalled_Then_ShouldReturnFalse()
        {
            //Arrange
            string title = "Fresh Off The Golf Course, Trump Lashes Out At FBI Deputy Director And James Comey";
            string text = "Donald Trump spent a good portion of his day at his golf club, marking the 84th day he s done so since taking the oath of office. It must have been a bad game because just after that, Trump lashed out at FBI Deputy Director Andrew McCabe on Twitter following a report saying McCabe plans to retire in a few months.";
            string subject = "News";

            //Act
            bool result = NewsPrediction.Predict(title, text, subject);

            //Assert
            result.Should().BeFalse();


        }

    }
}
