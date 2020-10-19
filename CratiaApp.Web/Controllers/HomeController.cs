using AutoMapper;
using CratiaApp.Bussines.Logic.Services;
using CratiaApp.Web.App_Start;
using CratiaApp.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CratiaApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IMapper _mapper = AutoMapperConfig.Mapper;
        private readonly IBoxerService _boxerService;

        public HomeController(IBoxerService boxerService)
        {
            _boxerService = boxerService;
        }

        public ActionResult Index()
        {
            var boxers = _boxerService.GetAllBoxers();
            var model = _mapper.Map<List<BoxerViewModel>>(boxers);

            return View(model);
        }
    }
}