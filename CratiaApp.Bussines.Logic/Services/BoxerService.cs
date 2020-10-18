using CratiaApp.Bussines.Logic.DTOs;
using CratiaApp.DataAccess.Entities;
using CratiaApp.DataAccess.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace CratiaApp.Bussines.Logic.Services
{
    public interface IBoxerService
    {
        IEnumerable<BoxerDTO> GetAllBoxers();        
    }
    public class BoxerService : ServiceBase, IBoxerService
    {
        public BoxerService(ICratiaAppUnitOfWork unitOfWork) : base (unitOfWork) { }

        public IEnumerable<BoxerDTO> GetAllBoxers()
        {
            var battles = _unitOfWork.GetRepository<Battle>()
                .GetAll()
                .ToList();

            List<BoxerDTO> boxers = new List<BoxerDTO>();

            for (int i = 0; i < battles.Count; i++)
            {
                var winner = boxers.SingleOrDefault(b => b.Name == battles[i].Winner);
                if (winner == null)
                {
                    boxers.Add(new BoxerDTO { Name = battles[i].Winner, Wins = 1, Loses = 0 });
                } 
                else 
                { 
                    boxers.Single(b => b.Name == battles[i].Winner).Wins += 1; 
                }

                var loser = boxers.SingleOrDefault(b => b.Name == battles[i].Loser);
                if (loser == null)
                {
                    boxers.Add(new BoxerDTO { Name = battles[i].Loser, Wins = 0, Loses = 1 });
                }
                else
                {
                    boxers.Single(b => b.Name == battles[i].Loser).Loses += 1;
                }
            }

            return boxers;
        }
    }
}
