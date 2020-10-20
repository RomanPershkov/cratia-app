using AutoMapper;
using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.Bussines.Logic.Services;
using CratiaApp.Web.App_Start;
using CratiaApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CratiaApp.Web.Controllers
{
    public class BattleController : Controller
    {
        private static readonly IMapper _mapper = AutoMapperConfig.Mapper;
        private readonly IBattleService _battleService;

        public BattleController(IBattleService battleService)
        {
            _battleService = battleService;
        }

        public ActionResult Index()
        {
            var dto = _battleService.GetAllBattleDTOs();
            var model = _mapper.Map<List<BattleViewModel>>(dto);

            return View(model);
        }
                
        public ActionResult AddBattle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBAttle(BattleViewModel model)
        {
            var battle = _mapper.Map<BattleDTO>(model);
            _battleService.AddBattle(battle);

            return RedirectToAction("Index");
        }
        
        
        public ActionResult EditBattle(Guid id)
        {
            var dto = _battleService.GetBattleById(id);
            var model = _mapper.Map<BattleViewModel>(dto);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditBattle(BattleViewModel model)
        {
            var battle = _mapper.Map<BattleDTO>(model);
            _battleService.EditBattle(battle);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteBattle(Guid id)
        {
            _battleService.DeleteBattle(id);

            return RedirectToAction("Index");
        }
    }
}