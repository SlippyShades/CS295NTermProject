using Microsoft.AspNetCore.Mvc;
using MTG295NTermProject.Models;

namespace MTG295NTermProject.Controllers
{
    public class QuizController : Controller
    {
        public Dictionary<int, String> Questions { get; set; }

        public Dictionary<int, String> Answers { get; set; }

        public QuizController()
        {
            Questions = new Dictionary<int, string>();
            Answers = new Dictionary<int, string>();
            Questions[1] = "Who made Magic the Gathering?";
            Questions[2] = "What is the worst color?";
            Questions[3] = "What is the best color?";
            Questions[4] = "Best Creature?";
            Questions[5] = "Do you pay the 1?";
            Answers[1] = "Richard Garfield";
            Answers[2] = "Blue";
            Answers[3] = "Green";
            Answers[4] = "Collosal Dreadmaw";
            Answers[5] = "No.";


        }

        public IActionResult Index()
        {
            var model = LoadQuestions(new QuizQuestions());
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string answer1, string answer2, string answer3, string answer4, string answer5)
        {
            var model = LoadQuestions(new QuizQuestions());
            model.UserAnswers[1] = answer1;
            model.UserAnswers[2] = answer2;
            model.UserAnswers[3] = answer3;
            model.UserAnswers[4] = answer4;
            model.UserAnswers[5] = answer5;

            model.checkAnswers();
            return View(model);
        }

        public QuizQuestions LoadQuestions(QuizQuestions model)
        {
            model.Questions = Questions;
            model.Answers = Answers;

            model.UserAnswers = new Dictionary<int, string>();
            model.Results = new Dictionary<int, bool>();

            foreach (var question in Questions)
            {
                int key = question.Key;
                model.UserAnswers[key] = "";
            }
            return model;
        }



    }
}