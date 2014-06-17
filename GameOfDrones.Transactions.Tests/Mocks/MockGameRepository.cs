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
    private GameData m_savedGameData;

    /// <summary>
    /// Returns the played games of a given player.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    /// <returns>Collection of games played by the given player.</returns>
    public IEnumerable<Engine.GameData> GetPlayedGames(string playerName)
    {
      ICollection<GameData> games = new List<GameData>();

      games.Add(m_savedGameData);

      return games;
    }

    /// <summary>
    /// Persists the data of the given game.
    /// </summary>
    /// <param name="gameData">The game data to persist.</param>
    public void SaveGameData(Engine.GameData gameData)
    {
      m_savedGameData = gameData;
    }
  }
}
