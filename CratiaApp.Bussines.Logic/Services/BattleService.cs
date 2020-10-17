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
    public interface IBattleService
    {

    }
    public class BattleService : ServiceBase, IBattleService
    {
        public BattleService(ICratiaAppUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        public void AddBattle(BattleDTO dto)
        {
            var battle = new Battle();
            _mapper.Map(dto, battle);

            _unitOfWork.GetRepository<Battle>().Add(battle);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<BattleDTO> GetBattlesByBoxerName(string name, string surname)
        {
            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname))
            {
                var findedBattles = _unitOfWork.GetRepository<Battle>()
                    .GetAllIncluding(b => b.Boxers)
                    .Where(c => c.Boxers.Select(d => d.Name).Contains(name))
                    .ToList();

                return _mapper.Map(findedBattles, new List<BattleDTO>());
            }
            else if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                var findedBattles = _unitOfWork.GetRepository<Battle>()
                    .GetAllIncluding(b => b.Boxers)
                    .Where(c => c.Boxers.Select(d => d.Surname).Contains(surname))
                    .ToList();

                return _mapper.Map(findedBattles, new List<BattleDTO>());
            }
            else if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(name))
            {
                var findedBattles = _unitOfWork.GetRepository<Battle>()
                    .GetAllIncluding(b => b.Boxers)
                    .Where(c => c.Boxers.Select(d => d.Name).Contains(name) && c.Boxers.Select(d => d.Surname).Contains(surname))
                    .ToList();

                return _mapper.Map(findedBattles, new List<BattleDTO>());
            }
            else 
                return null;
        }
    }
}
