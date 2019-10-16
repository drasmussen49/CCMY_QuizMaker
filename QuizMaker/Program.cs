using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to 'True or False?'!");
            QsAndAs firstSet = RunQuiz();
            firstSet.CheckAnswers();
            Console.ReadLine();
            
        }
        public static QsAndAs RunQuiz()
        {
            Console.WriteLine("Please choose which quiz to take: Type '1', '2', or '3' to choose a quiz.");
            string whichQuiz = Console.ReadLine();
            switch (whichQuiz)
            {
                case "1":
                    QsAndAs firstSet = new QsAndAs();
                    firstSet.Questions = new string[] { "Is broccoli a fruit?", "Is WoW Classic awesome?", "Did Arthas Menethil commit regicide?", "Has anyone really been far even decided to use even go want to do look more like??" };
                    firstSet.Answers = new bool[] { false, true, true, true };
                    firstSet.UserResponses = new bool[4];

                    if (firstSet.Questions.Length != firstSet.Answers.Length)
                    {
                        Console.WriteLine("Warning! Questions and answers arrays are not equal length. Done the goof, you have.");
                    }

                    int askingIndex = 0;

                    foreach (string question in firstSet.Questions)
                    {
                        string input;
                        bool isBool;
                        bool inputBool;
                        Console.WriteLine(question);
                        Console.WriteLine("True or false?");
                        input = Console.ReadLine();
                        isBool = Boolean.TryParse(input, out inputBool);
                        while (isBool == false)
                        {
                            Console.WriteLine("Please respond with 'true' or 'false'.");
                            input = Console.ReadLine();
                            isBool = Boolean.TryParse(input, out inputBool);
                        }
                        firstSet.UserResponses[askingIndex] = inputBool;
                        askingIndex++;
                    }
                    return firstSet;
                    

                default:
                    return null;
            }
           
        }
        
        
    }
    class QsAndAs
    {
        public string[] Questions
        { get; set; }
        
        public bool[] Answers
        { get; set; }

        public bool[] UserResponses
        { get; set; }

        public void CheckAnswers()
        {
            int scoringIndex = 0;
            int score = 0;
            foreach (bool answer in Answers)
            {
                bool userAnswer = UserResponses[scoringIndex];
                Console.WriteLine($"1. Input: {userAnswer} | Answer: {answer}");
                if (userAnswer == answer)
                {
                    score++;
                }
                scoringIndex++;
            }
            Console.WriteLine($"You got {score} out of 4 correct!");
        }
    }

}
