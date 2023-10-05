using MovieStore.Model;

namespace MovieStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
           MovieController controller = new MovieController();
            controller.Start();
        }
    }
}