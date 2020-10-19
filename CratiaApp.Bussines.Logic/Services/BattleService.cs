using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.DataAccess.Entities;
using CratiaApp.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CratiaApp.Bussines.Logic.Services
{
    public interface IBattleService
    {
        void AddBattle(BattleDTO dto);
        void EditBattle(BattleDTO dto);
        void DeleteBattle(Guid id);
        BattleDTO GetBattleById(Guid id);
        IEnumerable<BattleDTO> GetAllBattleDTOs();
    }
    public class BattleService : ServiceBase, IBattleService
    {
        public readonly IBoxerService _boxerService;

        public BattleService(ICratiaAppUnitOfWork unitOfWork, IBoxerService boxerService) : base(unitOfWork) 
        {
            _boxerService = boxerService;
        }
        
        public void AddBattle(BattleDTO dto)
        {
            var battle = new Battle();
            _mapper.Map(dto, battle);            

            _unitOfWork.GetRepository<Battle>().Add(battle);
                        
            _unitOfWork.SaveChanges();
        }

        public void EditBattle(BattleDTO dto)
        {
            var battle = _unitOfWork.GetRepository<Battle>()
                .GetAll()
                .Single(b => b.Id == dto.Id);

            _mapper.Map(dto, battle);
            _unitOfWork.SaveChanges();
        }

        public void DeleteBattle(Guid id)
        {
            var battle = _unitOfWork.GetRepository<Battle>()
                .GetAll()
                .Single(b => b.Id == id);

            _unitOfWork.GetRepository<Battle>().Delete(battle);
            _unitOfWork.SaveChanges();
        }

        public BattleDTO GetBattleById(Guid id)
        {
            var battle = _unitOfWork.GetRepository<Battle>()
                .GetAll()
                .Single(b => b.Id == id);

            return _mapper.Map<BattleDTO>(battle);
        }

        public IEnumerable<BattleDTO> GetAllBattleDTOs()
        {
            var battles = _unitOfWork.GetRepository<Battle>()
                .GetAll()
                .ToList();

            return _mapper.Map<List<BattleDTO>>(battles);
        }                
    }
}
