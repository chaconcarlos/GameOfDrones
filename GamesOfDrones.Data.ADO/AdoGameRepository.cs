using GameOfDrones.Data;
using GameOfDrones.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOfDrones.Data.ADO
{
  public class AdoGameRepository : IGameRepository, IDisposable
  {
    private GameEngineContext m_context;

    public AdoGameRepository()
    {
      m_context = new GameEngineContext();
    }

    /// <summary>
    /// Diposes the managed and native resources of this class.
    /// </summary>
    /// <param name="cleanAll">True, if both the managed 
    /// and native resources must be disposed. False only
    /// disposes native resources.</param>
    protected virtual void Dispose(bool cleanAll)
    {
      m_context.Dispose();
    }

    /// <summary>
    /// Returns the played games of a given player.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    /// <returns>Collection of games played by the given player.</returns>
    public IEnumerable<GameData> GetPlayedGames(string playerName)
    {
      return m_context.Games.Where(
        g => (g.Player1Name == playerName || g.Player2Name == playerName));
    }

    /// <summary>
    /// Persists the data of the given game.
    /// </summary>
    /// <param name="gameData">The game to persist.</param>
    public void SaveGameData(GameData gameData)
    {
      m_context.Games.Add(gameData);
      
      m_context.SaveChanges();
    }

    /// <summary>
    /// Disposes the managed and native resources of this class.
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }
  }
}
