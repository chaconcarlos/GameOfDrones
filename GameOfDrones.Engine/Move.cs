using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Engine
{
    /// <summary>
    /// Represents a possible move, and the kills that can make in any play.
    /// </summary>
    public class Move : ICloneable
    {
      private string              m_name;
      private ICollection<string> m_kills = new List<string>();

      /// <summary>
      /// Gets the name of the move.
      /// </summary>
      public string Name
      {
        get 
        { 
          return m_name; 
        }
      }

      /// <summary>
      /// Gets the list of kills for this move.
      /// </summary>
      protected ICollection<string> Kills
      {
        get
        {
          return m_kills;
        }
      }

      /// <summary>
      /// Creates an instance of the Move class.
      /// </summary>
      /// <param name="moveName">The name of the Move.</param>
      public Move(string moveName)
      {
        if (string.IsNullOrEmpty(moveName))
          throw new ArgumentException(
            GameEngineMessages.CreateMoveEmptyNameError);

        this.m_name = moveName;
      }

      /// <summary>
      /// Adds a kill.
      /// </summary>
      /// <param name="killName">Name of the kill.</param>
      public void AddKill(string killName)
      {
        if (string.IsNullOrEmpty(killName))
          throw new ArgumentException(
            GameEngineMessages.CreateMoveEmptyNameError);

        if (this.Name.Equals(killName, StringComparison.OrdinalIgnoreCase))
          throw new ArgumentException(
            GameEngineMessages.AddKillMoveSameNameAssMoveError);

        Kills.Add(killName);
      }

      /// <summary>
      /// Verifies the result of a play with this move and another move.
      /// </summary>
      /// <param name="moveName">Name of the move.</param>
      /// <returns>Result of the play.</returns>
      public virtual PlayResult Play(string moveName)
      {
        if (string.IsNullOrEmpty(moveName))
          throw new ArgumentException(
            GameEngineMessages.PlayEmptyMoveNameError);

        if (moveName.Equals(this.Name, StringComparison.OrdinalIgnoreCase))
          return PlayResult.Draw;

        if (Kills.Contains(moveName))
          return PlayResult.Win;

        return PlayResult.Lose;
      }

      public object Clone()
      {
        Move clone    = new Move(this.Name);
        clone.m_kills = new List<string>(this.Kills);

        return clone;
      }
    }
}
