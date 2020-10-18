using AutoMapper;
using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.DataAccess.Entities;

namespace CratiaApp.Bussines.Logic.AutoMapperConfiguration
{
    internal class SharedAutoMapperConfiguration
    {
        public SharedAutoMapperConfiguration(IMapperConfigurationExpression cfg)
        {
            RegisterToDTOMappings(cfg);
            RegisterToEFEntitiesMappings(cfg);
        }

        private void RegisterToDTOMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Battle, BattleDTO>();                        
        }

        private void RegisterToEFEntitiesMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<BattleDTO, Battle>()
                .ForMember(s => s.Id, dto => dto.Ignore());
        }
    }
}
