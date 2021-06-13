using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using SchoolApp.Domain.Repositories.Queries;

namespace SchoolApp.ConsoleUI.Controllers
{
    public class AppMenu
    {
        private IConfiguration _config;
        private ILogger<AppMenu> _logger;
        private IStudentQueryRepository _studentRepository;
        private string name => nameof(AppMenu);

        public AppMenu(IConfiguration config, ILogger<AppMenu> logger, IStudentQueryRepository studentRepository)
        {
            _config = config;
            _logger = logger;
            _studentRepository = studentRepository;
        }
        
        private IConfigurationSection getConfigs(string funcName) => _config.GetSection($"{ name }:{ funcName }");

        public void Start()
        {
            InitialGreet();
            NavigationOptions();
            System.Console.ReadKey();
        }

        private void InitialGreet()
        {
            var greet = getConfigs(nameof(InitialGreet)).Get<string>();

            System.Console.WriteLine();
            _logger.LogInformation(greet);
            System.Console.WriteLine();
        }    

        private void NavigationOptions() 
        {
            var options = getConfigs(nameof(NavigationOptions)).Get<List<string>>();

            _logger.LogInformation("Please select an option");

            for(var index=0; index < options.Count; index++)
                _logger.LogInformation("{optionIndex}-{optionName}",index, options[index]);
        }

    }
}