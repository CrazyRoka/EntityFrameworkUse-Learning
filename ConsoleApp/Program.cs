using EntityFrameworkCoreDatabaseFirst.Models;
using EntityFrameworkCoreUse.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EntityFrameworkCoreUse.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.InitializeServices();
            program.Start();
        }

        public void Start()
        {
            var unitOfWork = Container.GetRequiredService<UnitOfWork>();
            var commands = new ICommand[]
            {
                new ShowAllTeamCommand(),
                new ShowAllFootballerCommand(),
                new AddTeamCommand(),
                new AddFootballerCommand(),
                new DeleteTeamCommand(),
                new DeleteFootballerCommand(),
                new UpdateTeamCommand(),
                new UpdateFootballerCommand()
            };

            while (true)
            {
                PrintMenu(commands);
                var input = Console.ReadLine().Trim();
                Console.Clear();

                if (input == "q")
                {
                    Console.WriteLine("Thanks for using my App :)");
                    Console.Read();
                    break;
                }

                if(!int.TryParse(input, out int choice) || choice > commands.Length || choice < 1)
                {
                    Console.WriteLine("Invalid choice. Try again");
                    continue;
                }

                commands[choice - 1].Execute(unitOfWork);

                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void PrintMenu(ICommand[] commands)
        {
            Console.WriteLine("Enter option:");

            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {commands[i].Description}");
            }
            
            Console.WriteLine("Enter q to quit");
        }

        private void InitializeServices()
        {
            const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=FootballTeam;Trusted_Connection=True;";
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddFile("Logs/queries.txt");

            var services = new ServiceCollection();
            services.AddTransient<UnitOfWork>()
                .AddSingleton(loggerFactory)
                .AddEntityFrameworkSqlServer()
                .AddDbContext<TeamContext>(options =>
                    options.UseSqlServer(ConnectionString));
            Container = services.BuildServiceProvider();
        }

        public ServiceProvider Container { get; private set; }
    }
}
