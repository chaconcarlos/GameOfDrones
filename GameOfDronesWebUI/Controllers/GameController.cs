using GameOfDrones.Data;
using GameOfDrones.Engine;
using GameOfDrones.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GameOfDronesWebUI.Controllers
{
    public class GameController : ApiController
    {
      /// <summary>
      /// Gets the game rules.
      /// </summary>
      /// <returns>The game rules.</returns>
      [NonAction]
      private GameRules GetGameRules()
      {
        int       maxWins = 3;
        Move      move1   = new Move("Rock");
        Move      move2   = new Move("Scissors");
        Move      move3   = new Move("Paper");
        GameRules rules   = new GameRules(maxWins);

        move1.AddKill(move2.Name);
        move2.AddKill(move3.Name);
        move3.AddKill(move1.Name);

        rules.AddMove(move1);
        rules.AddMove(move2);
        rules.AddMove(move3);

        return rules;
      }

      /// <summary>
      /// Register a finished game result.
      /// </summary>
      /// <param name="game"></param>
      // POST api/savegameresult
      [NonAction]
      public void RegisterGameResult(Game game)
      {
        RegisterGameResult transaction =
          TransactionFactory.GetRegisterGameResultTransaction(game);

        transaction.Execute();
      }

      /// <summary>
      /// Gets the current started game.
      /// </summary>
      /// <param name="sessionId">The game session id.</param>
      /// <returns>The current started game.</returns>
      [NonAction]
      private Game GetStartedGame(string sessionId)
      {
        return GameSessionManager.GetGame(sessionId);
      }

      [ActionName("moves")]
      public IEnumerable<string> GetAvailableMoves(string sessionId)
      {
        Game game = GetStartedGame(sessionId);

        return game.AvailableMoves;
      }


      /// <summary>
      /// Gets the games played by a given player.
      /// </summary>
      /// <param name="id">Name of the player.</param>
      /// <returns>List of played games by the player.</returns>
      // GET api/getplayedgames
      [HttpGet]
      [ActionName("played")]
      public IEnumerable<GameData> Get(string id)
      {
        GetPlayedGamesByPlayer transaction =
          TransactionFactory.GetListGamesPlayedTransaction(id);

        transaction.Execute();

        return transaction.GetResult();
      }

      /// <summary>
      /// Starts the game.
      /// </summary>
      /// <param name="player1Name">The name for Player 1.</param>
      /// <param name="player2Name">The name for Player 2.</param>
      // POST api/startgame
      [HttpGet]
      [ActionName("Start")]
      public string StartGame(string player1Name, string player2Name)
      {
        string sessionId = GameSessionManager.StartGame(
          GetGameRules(), player1Name, player2Name);

        return sessionId;
      }

      /// <summary>
      /// Makes a play.
      /// </summary>
      /// <param name="sessionId">Game session Id.</param>
      /// <param name="player1MoveName">The player 1's move name.</param>
      /// <param name="player2MoveName">The player 2's move name.</param>
      /// <returns>The game data after the play.</returns>
      // GET api/makeplay
      [HttpGet]
      [ActionName("Play")]
      public GameData MakePlay(
        string sessionId, 
        string player1MoveName, 
        string player2MoveName)
      {
        Game game = GetStartedGame(sessionId);

        game.Play(player1MoveName, player2MoveName);

        if (game.HasWinner())
        {
          RegisterGameResult(game);

          GameSessionManager.FinishGame(sessionId);
        }

        return game.Data;
      }
    }
}
