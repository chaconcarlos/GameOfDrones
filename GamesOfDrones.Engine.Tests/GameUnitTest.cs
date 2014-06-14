using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Engine;

namespace GamesOfDrones.Engine.Tests
{
  [TestClass]
  public class GameUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_RulesWithNoMoves_ArgumentException()
    {
      //Arrange
      GameRules rules = new GameRules(3);

      //Act
      Game game = new Game(rules, "player1", "player2");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_Player1NameEmpty_ArgumentException()
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


      //Act
      Game game = new Game(rules, string.Empty, "player2");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_Player2NameEmpty_ArgumentException()
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


      //Act
      Game game = new Game(rules, "player1", string.Empty);
    }

    [TestMethod]
    public void Play_Player1WinsPlay_ScorePlayer1()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      string playWinnerName = game.Play(move1.Name, move2.Name);

      //Assert
      Assert.AreEqual(1,         game.ScorePlayer1);
      Assert.AreEqual("player1", playWinnerName);
    }

    [TestMethod]
    public void Play_Player2WinsPlay_ScorePlayer2()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      string playWinnerName = game.Play(move2.Name, move1.Name);

      //Assert
      Assert.AreEqual(1,         game.ScorePlayer2);
      Assert.AreEqual("player2", playWinnerName);
    }

    [TestMethod]
    public void Play_PlayerMakeSameMove_Draw()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      string playWinnerName = game.Play(move1.Name, move1.Name);

      //Assert
      Assert.AreEqual(0,            game.ScorePlayer1);
      Assert.AreEqual(0,            game.ScorePlayer2);
      Assert.AreEqual(string.Empty, playWinnerName);
    }

    [TestMethod]
    public void HasWinner_Player1WinsMaxTimes_HasWinner()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(move1.Name, move2.Name);
      game.Play(move3.Name, move1.Name);
      game.Play(move2.Name, move3.Name);

      //Assert
      Assert.AreEqual(true,      game.HasWinner());
      Assert.AreEqual("player1", game.getWinnerName());
    }

    [TestMethod]
    public void HasWinner_Player2WinsMaxTimes_HasWinner()
    {
      //Arrange
      int maxWins = 3;
      Move move1 = new Move("Rock");
      Move move2 = new Move("Scissors");
      Move move3 = new Move("Paper");
      GameRules rules = new GameRules(maxWins);

      move1.AddKill(move2.Name);
      move2.AddKill(move3.Name);
      move3.AddKill(move1.Name);

      rules.AddMove(move1);
      rules.AddMove(move2);
      rules.AddMove(move3);

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(move2.Name, move1.Name);
      game.Play(move1.Name, move3.Name);
      game.Play(move3.Name, move2.Name);

      //Assert
      Assert.AreEqual(true, game.HasWinner());
      Assert.AreEqual("player2", game.getWinnerName());
    }

    [TestMethod]
    public void HasWinner_NoMaxWinsReached_NoWinner()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(move1.Name, move2.Name);
      game.Play(move3.Name, move1.Name);

      //Assert
      Assert.AreEqual(false,        game.HasWinner());
      Assert.AreEqual(string.Empty, game.getWinnerName());
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Play_GameHasWinner_InvalidOperationException()
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

      Game game = new Game(rules, "player1", "player2");

      game.Play(move1.Name, move2.Name);
      game.Play(move3.Name, move1.Name);
      game.Play(move2.Name, move3.Name);

      //Act
      game.Play(move2.Name, move3.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Play_Player1MoveNameEmpty_ArgumentException()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(string.Empty, move3.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Play_Player2MoveNameEmpty_ArgumentException()
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

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(move3.Name, string.Empty);
    }
  }
}
