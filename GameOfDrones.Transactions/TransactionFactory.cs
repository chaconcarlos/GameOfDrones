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
  /// Represents the factory for Game Of Drones transactions.
  /// </summary>
  public static class TransactionFactory
  {
    /// <summary>
    /// Gets a ne instance of the GetPlayedGamesByPlayer transaction.
    /// </summary>
    /// <param name="playerName"></param>
    /// <returns></returns>
    public static GetPlayedGamesByPlayer GetListGamesPlayedTransaction
      (string playerName)
    {
      IGameRepository        repository  =
          RepositoryFactory.GetGameRepository();
      GetPlayedGamesByPlayer transaction =
        new GetPlayedGamesByPlayer(repository, playerName);

      return transaction;
    }

    public static RegisterGameResult GetRegisterGameResultTransaction
      (Game game)
    {
      IGameRepository        repository  =
          RepositoryFactory.GetGameRepository();
      RegisterGameResult     transaction = 
        new RegisterGameResult(repository, game);

      return transaction;
    }
  }
}
