using GameOfDrones.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Transactions.Tests.Mocks
{
  class MockRepositoryFactory : IRepositoryFactory
  {
    /// <summary>
    /// Gets an instance of the game repository.
    /// </summary>
    /// <returns>Instance of the game repository</returns>
    public IGameRepository GetGameRepository()
    {
      return new MockGameRepository();
    }
  }
}
