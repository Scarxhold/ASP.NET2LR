using LR2_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LR2_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyAnalyzerService _companyAnalyzerService;
        private readonly IConfiguration _configuration;

        public HomeController(CompanyAnalyzerService companyAnalyzerService, IConfiguration configuration)
        {
            _companyAnalyzerService = companyAnalyzerService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var largestCompany = _companyAnalyzerService.GetLargestCompany();

            var name = _configuration["Name"];
            var age = _configuration["Age"];
            var university = _configuration["University"];
            var specialty = _configuration["Specialty"];

            var model = new HomeViewModel
            {
                LargestCompany = largestCompany,
                Name = name,
                Age = age,
                University = university,
                Specialty = specialty
            };

            return View(model);
        }
    }

}
