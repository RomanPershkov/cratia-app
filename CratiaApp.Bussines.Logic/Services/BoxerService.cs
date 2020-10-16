using CratiaApp.DataAccess.Entities;
using CratiaApp.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CratiaApp.Bussines.Logic.Services
{
    public interface IBoxerService
    {
        void AddBoxer(BoxerDTO dto);
        Boxer GetBoxerByName(string name);
        Boxer GetBoxerBySurname(string surname);
        Boxer GetBoxerByFullName(string name, string surname);
    }
    public class BoxerService : ServiceBase, IBoxerService
    {
        public BoxerService(ICratiaAppUnitOfWork unitOfWork) : base (unitOfWork) { }
        
        public void AddBoxer(BoxerDTO dto)
        {
            var boxer = new Boxer();

            _mapper.Map(dto, boxer);
        }

        public Boxer GetBoxerByName(string name)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Name == name);                        
        }

        public Boxer GetBoxerBySurname(string surname)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Surname == surname);
        }

        public Boxer GetBoxerByFullName(string name, string surname)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Name == name && b.Surname == surname);
        }
    }
}
