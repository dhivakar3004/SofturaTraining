using System;
using System.Linq;

namespace UnderstandingLinq
{
    class Program
    { int[] feedbackScores = { 32, 98, 52, 79, 43, 62, 44, 52, 79 };
        IQueryable<int> numbers;
        void printLowFeedbackCount()
        {
            int count = feedbackScores.Where(score => score < 50).Count();
            Console.WriteLine("The number of low feedback is {0}",count);
        }
        void printFeedbackInAscendingOrder()
        {
            var sortedfeedback = feedbackScores.OrderBy(score => score);
            Console.WriteLine("Printing the sorted feedback");
            foreach (var item in sortedfeedback)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().printFeedbackInAscendingOrder();
            new Program().printLowFeedbackCount();
            
        }
    }
}
