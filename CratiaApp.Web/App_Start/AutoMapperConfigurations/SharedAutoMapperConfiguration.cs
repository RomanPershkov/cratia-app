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
            cfg.CreateMap<BoxerViewModel, BoxerDTO>()/*
                .ForMember(d => d.Birthdate, vm => vm.PreCondition(d => string.IsNullOrEmpty(d.Birthdate) == false))
                .ForMember(d => d.Birthdate, vm => vm.MapFrom(d => DateTime.ParseExact(d.Birthdate, "dd.MM.yyyy", new CultureInfo("ru-RU"))))*/;
        }
    }
}