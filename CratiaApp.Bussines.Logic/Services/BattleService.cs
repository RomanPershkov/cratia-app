using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.DataAccess.Entities;
using CratiaApp.DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace CratiaApp.Bussines.Logic.Services
{
    public interface IBattleService
    {
        void AddBattle(BattleDTO dto);
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

        public IEnumerable<BattleDTO> GetAllBattleDTOs()
        {
            var battles = _unitOfWork.GetRepository<Battle>()
                .GetAllIncluding(b => b.Loser, c => c.Winner)
                .ToList();

            return _mapper.Map<List<BattleDTO>>(battles);
        }                
    }
}
