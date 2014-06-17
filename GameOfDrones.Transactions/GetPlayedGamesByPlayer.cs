using GameOfDrones.Data;
using GameOfDrones.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Transactions
{
  /// <summary>
  /// Represents a transaction that gets the completed played games for a player.
  /// </summary>
  public class GetPlayedGamesByPlayer : IScalarTransaction<IEnumerable<GameData>>
  {
    private string                m_playerName;
    private IGameRepository       m_repository;
    private IEnumerable<GameData> m_result;

    /// <summary>
    /// Creates an instance of the GetPlayedGamesByPlayer class.
    /// </summary>
    /// <param name="repository">The game data repository.</param>
    /// <param name="playerName">The player Name.</param>
    public GetPlayedGamesByPlayer(Data.IGameRepository repository, string playerName)
    {
      if (repository == null)
        throw new ArgumentException(GameTransactionMessages.RepositoryIsNullError);

      if (string.IsNullOrEmpty(playerName))
        throw new ArgumentException(GameTransactionMessages.PlayerNameIsEmptyError);

      this.m_repository = repository;
      this.m_playerName = playerName;
    }
    /// <summary>
    /// Gets the result of the transaction.
    /// </summary>
    /// <returns>The result of the transaction.</returns>
    public IEnumerable<GameData> GetResult()
    {
      return m_result;
    }

    /// <summary>
    /// Executes the transaction.
    /// </summary>
    public void Execute()
    {
      m_result = m_repository.GetPlayedGames(m_playerName);
    }
  }
}
