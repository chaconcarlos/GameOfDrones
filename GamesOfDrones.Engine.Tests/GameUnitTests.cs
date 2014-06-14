using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Engine;

namespace GamesOfDrones.Engine.Tests
{
  /// <summary>
  /// Summary description for GameUnitTests
  /// </summary>
  [TestClass]
  public class GameUnitTests
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
      int maxWins     = 3;
      Move move1      = new Move("Rock");
      Move move2      = new Move("Scissors");
      Move move3      = new Move("Paper");
      GameRules rules = new GameRules(maxWins);

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
      int maxWins     = 3;
      Move move1      = new Move("Rock");
      Move move2      = new Move("Scissors");
      Move move3      = new Move("Paper");
      GameRules rules = new GameRules(maxWins);

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
      int maxWins     = 3;
      Move move1      = new Move("Rock");
      Move move2      = new Move("Scissors");
      Move move3      = new Move("Paper");
      GameRules rules = new GameRules(maxWins);

      move1.AddKill(move2.Name);
      move2.AddKill(move3.Name);
      move3.AddKill(move1.Name);

      rules.AddMove(move1);
      rules.AddMove(move2);
      rules.AddMove(move3);

      Game game = new Game(rules, "player1", "player2");

      //Act
      game.Play(move1.Name, move2.Name);

      //Assert
      Assert.AreEqual(1, game.ScorePlayer1);
    }

    [TestMethod]
    public void Play_Player2WinsPlay_ScorePlayer2()
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

      //Assert
      Assert.AreEqual(1, game.ScorePlayer2);
    }

    [TestMethod]
    public void Play_PlayerMakeSameMove_Draw()
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
      game.Play(move1.Name, move1.Name);

      //Assert
      Assert.AreEqual(0, game.ScorePlayer1);
      Assert.AreEqual(0, game.ScorePlayer2);
    }
  }
}
