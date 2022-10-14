using Microsoft.Extensions.DependencyInjection;

namespace Module3HW2
{
    public class Program
    {
        private static void Main()
        {
            var start = new ServiceCollection()
               .AddTransient<IAlphabetService, AlphabetService>()
               .AddTransient<Starter>()
               .BuildServiceProvider();
            var application = start.GetService<Starter>();
            application.Run();
        }
    }
}
