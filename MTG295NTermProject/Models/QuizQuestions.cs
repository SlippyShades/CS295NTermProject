using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace MTG295NTermProject.Models
{
    public class QuizQuestions
    {
        public Dictionary<int, String> Questions { get; set; }
        public Dictionary<int, String> Answers { get; set; }
        public Dictionary<int, String> UserAnswers { get; set; }
        public Dictionary<int, bool> Results { get; set; }

        public void checkAnswers()
        {
            foreach (var question in Questions)
            {
                int key = question.Key;
                Results[key] = Answers[key] == UserAnswers[key];
            }
        }



    }
}
