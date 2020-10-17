using CratiaApp.Bussines.Logic.DTOs;
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
        IEnumerable<BoxerDTO> GetAllBoxers();
        /*BoxerDTO GetBoxerByName(string name);
        BoxerDTO GetBoxerBySurname(string surname);
        BoxerDTO GetBoxerByFullName(string name, string surname);*/
    }
    public class BoxerService : ServiceBase, IBoxerService
    {
        public BoxerService(ICratiaAppUnitOfWork unitOfWork) : base (unitOfWork) { }

        public IEnumerable<BoxerDTO> GetAllBoxers()
        {
            var boxers = _unitOfWork.GetRepository<Boxer>().GetAllIncluding(b => b.Battles).ToList();

            return _mapper.Map(boxers, new List<BoxerDTO>());
        }
        
        public void AddBoxer(BoxerDTO dto)
        {
            var boxer = new Boxer();

            _mapper.Map(dto, boxer);

            _unitOfWork.GetRepository<Boxer>().Add(boxer);
            _unitOfWork.SaveChanges();
        }
                
        /*public BoxerDTO GetBoxerByName(string name)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Name == name);                        
        }

        public BoxerDTO GetBoxerBySurname(string surname)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Surname == surname);
        }

        public BoxerDTO GetBoxerByFullName(string name, string surname)
        {
            return _unitOfWork.GetRepository<Boxer>().GetAllIncluding("Battles").Single(b => b.Name == name && b.Surname == surname);
        }*/
    }
}
