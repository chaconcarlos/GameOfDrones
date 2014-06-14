using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Transactions
{
  /// <summary>
  /// Represents a transaction that returns a result.
  /// </summary>
  /// <typeparam name="ResultType">Type of the result</typeparam>
  public interface IScalarTransaction<ResultType> : ITransaction
  {
    /// <summary>
    /// Gets the result of the transaction.
    /// </summary>
    /// <returns>The result of the transaction.</returns>
    public ResultType GetResult();
  }
}
