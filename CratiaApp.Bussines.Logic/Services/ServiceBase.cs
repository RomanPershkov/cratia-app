using AutoMapper;
using CratiaApp.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CratiaApp.Bussines.Logic.Services
{
    public abstract class ServiceBase
    {
        protected readonly ICratiaAppUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper = AutoMapperConfig.Mapper;

        public ServiceBase(ICratiaAppUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
