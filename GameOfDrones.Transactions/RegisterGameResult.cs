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
    /// Represents the transaction that persists the result of game.
    /// </summary>
    public class RegisterGameResult : ITransaction
    {
      private IGameRepository m_repository;
      private Game            m_game;

      /// <summary>
      /// Creates an instance of the RegisterGameResult class.
      /// </summary>
      /// <param name="repository">The game data repository.</param>
      /// <param name="game">The game to register.</param>
      public RegisterGameResult(IGameRepository repository, Game game)
      {
        this.m_repository = repository;
        this.m_game       = game;
      }

      /// <summary>
      /// Executes the transaction.
      /// </summary>
      public void Execute()
      {
        if (!m_game.HasWinner())
          throw new InvalidOperationException(
            GameTransactionMessages.SaveGameDoesNotHaveWinnerError);

        m_repository.SaveGame(m_game);
      }
    }
}
