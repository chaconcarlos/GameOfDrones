using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
  /// <summary>
  /// Represents a factory for data repositories.
  /// </summary>
  public interface IRepositoryFactory
  {
    /// <summary>
    /// Gets an instance of the game repository.
    /// </summary>
    /// <returns>Instance of the game repository</returns>
    IGameRepository GetGameRepository();
  }
}
