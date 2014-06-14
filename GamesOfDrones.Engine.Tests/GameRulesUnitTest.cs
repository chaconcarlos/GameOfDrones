using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GameOfDrones.Engine;
using GameOfDrones.Exceptions;

namespace GamesOfDrones.Engine.Tests
{
  [TestClass]
  public class GameRulesUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_MaxWinsIsZero_ThrowArgumentException()
    {
      //Arrange
      int maxWins = 0;

      //Act
      GameRules rules = new GameRules(maxWins);
    }

    [TestMethod]
    public void AddMove_ValidMove_MoveExists()
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

      //Act
      rules.AddMove(move1);
      rules.AddMove(move2);
      rules.AddMove(move3);

      //Assert
      ICollection<string> moves = rules.GetMoves();

      Assert.AreEqual(3, moves.Count);
      Assert.AreEqual(move1.Name, rules.GetMove(move1.Name).Name);
      Assert.AreEqual(move2.Name, rules.GetMove(move2.Name).Name);
      Assert.AreEqual(move3.Name, rules.GetMove(move3.Name).Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ElementAlreadyExistsException))]
    public void AddMove_MoveAlreadyAdded_ThrowElementAlreadyExistsException()
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
      rules.AddMove(move1);
    }

    [TestMethod]
    [ExpectedException(typeof(ElementNotFoundException))]
    public void GetMove_MoveNotAdded_ThrowElementNotFoundException()
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
      rules.GetMove("Spock");
    }
  }
}
