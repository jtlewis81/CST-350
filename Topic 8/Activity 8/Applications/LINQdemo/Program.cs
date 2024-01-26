namespace LINQdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new[] { 91, 51, 64, 76, 95, 65, 86, 90, 75, 54, 86, 45};
            
            foreach (var score in scores)
            {
                Console.WriteLine("One of the scores was " + score);
            }

            Console.ReadLine();

            var bestScores = from score in scores
                             where score >= 90
                             select score;

            foreach(var score in bestScores)
            {
                Console.WriteLine("One of the BEST scores was " + score);
            }

            Console.ReadLine();

            var sortedScores = from score in scores
                               orderby score
                               select score;

            foreach(var score in sortedScores)
            {
                Console.WriteLine("One of the scores was " + score);
            }

            Console.ReadLine();

            var bScores = from score in scores
                          where score < 90 && score >= 80
                          select score;

            foreach (var score in bScores)
            {
                Console.WriteLine("One of the Grade B scores was " + score);
            }

            Console.ReadLine();

        }
    }
}
