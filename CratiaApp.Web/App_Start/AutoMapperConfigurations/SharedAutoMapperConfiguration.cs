using AutoMapper;
using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.Web.Models;
using System;

namespace CratiaApp.Web.App_Start.AutoMapperConfigurations
{
    internal class SharedAutoMapperConfiguration
    {
        public SharedAutoMapperConfiguration(IMapperConfigurationExpression cfg)
        {
            RegisterToViewModelMappings(cfg);
            RegisterToDTOMappings(cfg);
        }

        private void RegisterToViewModelMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BoxerDTO, BoxerViewModel>();
            cfg.CreateMap<BattleDTO, BattleViewModel>();
        }

        private void RegisterToDTOMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BoxerViewModel, BoxerDTO>();
            cfg.CreateMap<BattleViewModel, BattleDTO>();
        }
    }
}