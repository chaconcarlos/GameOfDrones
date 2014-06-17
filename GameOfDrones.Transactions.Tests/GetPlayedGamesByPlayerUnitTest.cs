using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Data;
using GameOfDrones.Engine;
using GameOfDrones.Transactions.Tests.Mocks;

namespace GameOfDrones.Transactions.Tests
{
  [TestClass]
  public class GetPlayedGamesByPlayerUnitTest
  {
    [TestInitialize]
    public void SetUp()
    {
      RepositoryFactory.InitializeFactory(new MockRepositoryFactory());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_PlayerNameIsEmpty_ArgumentException()
    {
      //Arrange
      IGameRepository repository = RepositoryFactory.GetGameRepository();
      
      //Act
      GetPlayedGamesByPlayer getPlayedTransaction =
        new GetPlayedGamesByPlayer(repository, string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_NullRepository_ArgumentException()
    {
      //Arrange
      IGameRepository repository = new MockGameRepository();

      //Act
      GetPlayedGamesByPlayer getPlayedTransaction =
        new GetPlayedGamesByPlayer(null, "Player1");
    }

    [TestMethod]
    public void Execute_ValidPlayer_GamesFound()
    {
      //Arrange
      IGameRepository repository = RepositoryFactory.GetGameRepository();
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

      RegisterGameResult registerGameTransaction = 
        new RegisterGameResult(repository, game);
      
      registerGameTransaction.Execute();

      GetPlayedGamesByPlayer getPlayedTransaction =  
        new GetPlayedGamesByPlayer(repository, "player1");

      //Act
      getPlayedTransaction.Execute();

      //Assert
      IEnumerable<GameData> result     = getPlayedTransaction.GetResult();
      GameData              playedGame = result.ElementAt(0);

      Assert.AreEqual(3,         playedGame.ScorePlayer1);
      Assert.AreEqual(0,         playedGame.ScorePlayer2);
      Assert.AreEqual("player1", playedGame.WinnerName);
    }
  }
}
