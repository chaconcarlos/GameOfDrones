using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Transactions
{
  /// <summary>
  /// Represents a transactional operation.
  /// </summary>
  public interface ITransaction
  {
    /// <summary>
    /// Executes the transaction.
    /// </summary>
    void Execute();
  }
}
