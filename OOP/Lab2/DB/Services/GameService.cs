using Lab2.DB.Services;
using Lab2.DB.Entity.Games;
using Lab2.DB.Repositories;
using Lab2.DB.Repositories.Base;
using Lab2.DB.Services.Base;
using Lab2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DB.Services
{
    public class GameService : IGameService
    {
        GameRepository repository;
        GameAccountService _serviceAcc;
        public GameService(DbContext context)
        {
            repository = new GameRepository(context);
            _serviceAcc= new GameAccountService(context);
        }
        public void Create(Game entity)
        {
            repository.Create(Map(entity));
        }
        public void Delete(Game entity)
        {
            repository.Delete(Map(entity));
        }
        public List<Game> GetAll()
        {
            var list = repository.GetAll().Select(x => Map(x)).ToList();
            return list;
        }
        public Game GetById(int id)
        {
            return Map(repository.GetById(id));
        }
        public void Update(Game entity)
        {
            repository.Update(Map(entity));
        }
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,
                
            };
        }
        private Game Map(GameEntity game)
        {
            return new Game(game.Player1, game.Player2, this)
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,
            };
        }
        private SingleRatingEntity Map(SingleRatingGame game)
        {
            return new SingleRatingEntity
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,

            };
        }
        private SingleRatingGame Map(SingleRatingEntity game)
        {
            return new SingleRatingGame(game.Player1, game.Player2, this)
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,
            };
        }
        private TraningGameEntity Map(TraningGame game)
        {
            return new TraningGameEntity
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,

            };
        }
        private TraningGame Map(TraningGameEntity game)
        {
            return new TraningGame(game.Player1, game.Player2, this)
            {
                Id = game.Gameid,
                Player1 = game.Gamer,
                Player2 = game.Opponent,
                PlayRating = game.Rating,
            };
        }
    }
}
