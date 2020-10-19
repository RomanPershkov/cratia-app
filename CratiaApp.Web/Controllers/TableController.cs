using AutoMapper;
using CratiaApp.Bussines.Logic.Services;
using CratiaApp.Web.App_Start;
using CratiaApp.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CratiaApp.Web.Controllers
{
    public class TableController : Controller
    {
        private static readonly IMapper _mapper = AutoMapperConfig.Mapper;
        private readonly IBattleService _battleService;

        public TableController(IBattleService battleService)
        {
            _battleService = battleService;
        }

        public string GetBattlesForTable()
        {
            var dto = _battleService.GetAllBattleDTOs();
            var model = _mapper.Map<List<BattleViewModel>>(dto);

            return JsonConvert.SerializeObject(model);
        }
        
        public ActionResult Index()
        {
            return View();
        }
    }
}