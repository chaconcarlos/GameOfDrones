using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfDrones.Engine;

namespace GamesOfDrones.Engine.Tests
{
  [TestClass]
  public class MoveUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Create_EmptyMoveName_ThrowArgumentException()
    {
      //Arrange
      string moveName = string.Empty;

      //Assert
      Move newMove = new Move(moveName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddKill_EmptyKillName_ThrowArgumentException()
    {
      //Arrange
      string moveName = "Rock";
      string killName = string.Empty;
      Move   newMove  = new Move(moveName);

      //Assert
      newMove.AddKill(killName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddKill_KillNameSameAsMove_ThrowArgumentException()
    {
      //Arrange
      string moveName = "Rock";
      Move   newMove  = new Move(moveName);

      //Assert
      newMove.AddKill(moveName);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Play_EmptyMoveName_ThrowArgumentException()
    {
      //Arrange
      string moveName        = "Rock";
      string againstMoveName = string.Empty;
      Move   newMove         = new Move(moveName);
      
      newMove.AddKill(againstMoveName);

      //Act
      PlayResult result = newMove.Play(againstMoveName);
    }

    [TestMethod]
    public void Play_ValidMoveName_Win()
    {
      //Arrange
      string moveName        = "Rock";
      string againstMoveName = "Scissors";
      Move   newMove         = new Move(moveName);
      
      newMove.AddKill(againstMoveName);

      //Act
      PlayResult result = newMove.Play(againstMoveName);

      //Assert
      Assert.AreEqual(PlayResult.Win, result);
    }

    [TestMethod]
    public void Play_SameMove_Draw()
    {
      //Arrange
      string moveName = "Rock";
      Move   newMove  = new Move(moveName);

      //Act
      PlayResult result = newMove.Play(moveName);

      //Assert
      Assert.AreEqual(PlayResult.Draw, result);
    }

    [TestMethod]
    public void Play_MoveNotOnKillList_Lose()
    {
      //Arrange
      string moveName        = "Rock";
      string againstMoveName = "Paper";
      Move   newMove         = new Move(moveName);

      //Act
      PlayResult result = newMove.Play(againstMoveName);

      //Assert
      Assert.AreEqual(PlayResult.Lose, result);
    }

    [TestMethod]
    public void Clone_CompleteMove_ValidClone()
    {
      //Arrange
      string moveName        = "Rock";
      string againstMoveName = "Paper";
      Move   move            = new Move(moveName);

      move.AddKill(againstMoveName);

      //Act
      Move clone = (Move) move.Clone();

      //Assert
      PlayResult result = clone.Play(againstMoveName);

      Assert.AreEqual(move.Name, clone.Name);
      Assert.AreEqual(move.Play(againstMoveName), clone.Play(againstMoveName));
    }
  }
}
