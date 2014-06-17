using GameOfDrones.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOfDrones.Data.ADO
{
  /// <summary>
  /// Represents the repository factory for ADO.Net.
  /// </summary>
  public class AdoRepositoryFactory : IRepositoryFactory
  {
    /// <summary>
    /// Gets an instance of the game repository.
    /// </summary>
    /// <returns>Instance of the game repository</returns>
    public IGameRepository GetGameRepository()
    {
      return new AdoGameRepository();
    }
  }
}
