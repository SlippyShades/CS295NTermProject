using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTG295NTermProject.Controllers;
using MTG295NTermProject.Data;
using MTG295NTermProject.Models;


namespace MTGTests
{
    public class CardDataTest
    {

        





        [Fact]
        public void QuizTest()
        {
            var controller = new QuizController();
            var model = new QuizQuestions();


            var loadedModel = controller.LoadQuestions(model);

            Assert.NotNull(loadedModel.Questions);
            Assert.NotNull(loadedModel.Answers);
            Assert.NotEmpty(loadedModel.Questions);
            Assert.NotEmpty(loadedModel.Answers);
            Assert.Equal(controller.Questions, loadedModel.Questions);
            Assert.Equal(controller.Answers, loadedModel.Answers);
            Assert.Equal(loadedModel.Questions.Count, loadedModel.Answers.Count);
        }

        [Fact]
        public void TestQuizAnswers()
        {
            var controller = new QuizController();
            var model = new QuizQuestions();
            var loadedModel = controller.LoadQuestions(model);

            loadedModel.UserAnswers[1] = "Richard Garfield"; //True
            loadedModel.UserAnswers[2] = "False"; //False
            loadedModel.UserAnswers[3] = "Green"; //True
            loadedModel.UserAnswers[4] = "False"; //False
            loadedModel.UserAnswers[5] = ""; //No answer, thus false

            loadedModel.checkAnswers();
            Assert.True(loadedModel.Results[1]);
            Assert.False(loadedModel.Results[2]);
            Assert.True(loadedModel.Results[3]);
            Assert.False(loadedModel.Results[4]);
            Assert.False(loadedModel.Results[5]);
        }
        [Fact]
        public void CardIsValid()
        {
            var card = new CardModel
            {
                CardName = "Goblin Guide",
                ManaCost = 1,
                CardType = AllowedTypes.CardType.Creature,
                CardColor = AllowedColors.CardColor.Red,
                PriceUSD = 3.5,
                OracleText = "Haste",
                Quantity = 4
            };
            var context = new ValidationContext(card);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(card, context, results, true);
            Assert.True(isValid);
        }
        [Fact]
        public void CardIsInvalid()
        {
            var card = new CardModel
            {
                CardName = "",
                ManaCost = 1,
                CardType = AllowedTypes.CardType.Creature,
                CardColor = AllowedColors.CardColor.Red,
                PriceUSD = 3.5,
                OracleText = "Haste",
                Quantity = 4
            };
            var context = new ValidationContext(card);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(card, context, results, true);
            Assert.False(isValid);
        }



    }
}
