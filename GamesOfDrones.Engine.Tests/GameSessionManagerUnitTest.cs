using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Engine;
using GameOfDrones.Exceptions;

namespace GamesOfDrones.Engine.Tests
{
  [TestClass]
  public class GameSessionManagerUnitTest
  {
    [TestInitialize]
    public void SetUp()
    {
      GameSessionManager.FinishAllGames();
    }

    [TestMethod]
    [ExpectedException(typeof(ElementNotFoundException))]
    public void GetGame_GameDoesNotExists_ThrowElementNotFoundException()
    {
      //Act
      GameSessionManager.GetGame("NotAGameId");
    }

    [TestMethod]
    public void GetGame_GameExists_GotTheCorrectGame()
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

      string sessionId = GameSessionManager.StartGame(rules, "player1", "player2");
      
      //Act
      Game game = GameSessionManager.GetGame(sessionId);

      //Assert
      Assert.AreEqual("player1", game.Player1Name);
      Assert.AreEqual("player2", game.Player2Name);
    }

    [TestMethod]
    public void GetGameSessionCount_OneGame_SessionCountIs1()
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

      string sessionId = GameSessionManager.StartGame(rules, "player1", "player2");

      //Act
      int sessionCount = GameSessionManager.GetCurrentStartedCount();

      //Assert
      Assert.AreEqual(1, sessionCount);
    }

    [TestMethod]
    public void FinishGame_OneGame_GameIsNotStarted()
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

      string sessionId = GameSessionManager.StartGame(rules, "player1", "player2");

      //Act
      GameSessionManager.FinishGame(sessionId);

      //Assert
      Assert.AreEqual(false, GameSessionManager.IsGameStarted(sessionId));
      Assert.AreEqual(0,     GameSessionManager.GetCurrentStartedCount());
    }

    [TestMethod]
    [ExpectedException(typeof(GameNotStartedException))]
    public void FinishGame_GameNotStarted_ThrowGameNotStartedException()
    {
      //Act
      GameSessionManager.FinishGame("NotValidGameSession");
    }

    [TestMethod]
    public void FinishAllGames_NoSessions_SessionCountIs0()
    {
      //Arrange
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

      GameSessionManager.StartGame(rules, "player1", "player2");
      GameSessionManager.StartGame(rules, "player1", "player2");
      GameSessionManager.StartGame(rules, "player1", "player2");

      //Act
      GameSessionManager.FinishAllGames();

      //Assert
      Assert.AreEqual(0, GameSessionManager.GetCurrentStartedCount());
    }
  }
}
