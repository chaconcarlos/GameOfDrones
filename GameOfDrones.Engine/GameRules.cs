using GameOfDrones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Engine
{
  /// <summary>
  /// Represents the rules of a game of drones gameplay.
  /// </summary>
  public class GameRules
  {
    private int                       m_maxWins;
    private IDictionary<string, Move> m_moves = new Dictionary<string, Move>();

    /// <summary>
    /// Gets the number of wins needed to declare a player as the winner.
    /// </summary>
    public int MaxWins
    {
      get 
      { 
        return m_maxWins; 
      }
    }

    /// <summary>
    /// Gets the dictionary that contains the moves.
    /// </summary>
    protected IDictionary<string, Move> Moves
    {
      get
      { 
        return m_moves; 
      }
    }

    /// <summary>
    /// Creates an instance of the GameRules class.
    /// </summary>
    /// <param name="maxWins">Number of wins needed to declare a player as 
    /// the winner.</param>
    public GameRules(int maxWins)
    {
      if (maxWins < 1)
        throw new ArgumentException(
          GameEngineMessages.CreateRulesMaxWinsZeroError);

      this.m_maxWins = maxWins;
    }

    /// <summary>
    /// Adds a move to the rules.
    /// </summary>
    /// <param name="move">Move to add.</param>
    public void AddMove(Move move)
    {
      if (Moves.Keys.Contains(move.Name))
        throw new ElementAlreadyExistsException(
          string.Format(GameEngineMessages.MoveAlreadyExitsError, move.Name));

      this.Moves.Add(move.Name, move);
    }

    /// <summary>
    /// Gets the list of moves names.
    /// </summary>
    /// <returns>List of moves names.</returns>
    public ICollection<string> GetMoves()
    {
      return Moves.Keys;
    }

    public Move GetMove(string moveName)
    {
      if (!Moves.Keys.Contains(moveName))
        throw new ElementNotFoundException(
          string.Format(GameEngineMessages.MoveNotFoundError, moveName));

      //Returns a clone so the rules cannot be changed.
      return (Move) Moves[moveName].Clone();
    }
  }
}
