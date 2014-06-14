using GameOfDrones.Data;
using GameOfDrones.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Transactions.Tests
{
  /// <summary>
  /// Represents a mock game repository for testing purposes.
  /// </summary>
  class MockGameRepository : IGameRepository
  {
    private Game m_savedGame;

    /// <summary>
    /// Returns the played games of a given player.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    /// <returns>Collection of games played by the given player.</returns>
    public IEnumerable<Engine.Game> getPlayedGames(string playerName)
    {
      ICollection<Game> games = new List<Game>();

      games.Add(m_savedGame);

      return games;
    }

    /// <summary>
    /// Persists the data of the given game.
    /// </summary>
    /// <param name="game">The game to persist.</param>
    public void SaveGame(Engine.Game game)
    {
      m_savedGame = game;
    }
  }
}
