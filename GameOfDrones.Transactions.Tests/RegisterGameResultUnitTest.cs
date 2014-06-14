using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Data;
using GameOfDrones.Engine;

namespace GameOfDrones.Transactions.Tests
{
    [TestClass]
    public class RegisterGameResultUnitTest
    {
      [TestMethod]
      public void Execute_GameHasWinner_GameRegistered()
      {
        //Arrange
        IGameRepository repository = new MockGameRepository();
        int             maxWins    = 3;
        Move            move1      = new Move("Rock");
        Move            move2      = new Move("Scissors");
        Move            move3      = new Move("Paper");
        GameRules       rules      = new GameRules(maxWins);

        move1.AddKill(move2.Name);
        move2.AddKill(move3.Name);
        move3.AddKill(move1.Name);

        rules.AddMove(move1);
        rules.AddMove(move2);
        rules.AddMove(move3);

        Game game = new Game(rules, "player1", "player2");

        game.Play(move1.Name, move2.Name);
        game.Play(move3.Name, move1.Name);
        game.Play(move2.Name, move3.Name);

        RegisterGameResult transaction = new RegisterGameResult(repository, game);

        //Act
        transaction.Execute();

        //Assert
        IEnumerable<Game> playedGamesList = repository.getPlayedGames("player1");
        Game              playedGame      = playedGamesList.ElementAt(0);

        Assert.AreEqual(true,      playedGame.HasWinner());
        Assert.AreEqual("player1", playedGame.getWinnerName());
      }

      [TestMethod]
      [ExpectedException(typeof(InvalidOperationException))]
      public void Execute_GameDoesNotHaveWinner_InvalidOperationException()
      {
        //Arrange
        IGameRepository repository = new MockGameRepository();
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

        Game game = new Game(rules, "player1", "player2");

        game.Play(move1.Name, move2.Name);
        game.Play(move3.Name, move1.Name);
        
        RegisterGameResult transaction = new RegisterGameResult(repository, game);

        //Act
        transaction.Execute();
      }
    }
}
