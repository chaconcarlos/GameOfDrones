using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Data
{
  /// <summary>
  /// Represents the data repository factory.
  /// </summary>
  public static class RepositoryFactory
  {
    static IRepositoryFactory m_currentFactory;

    public static void InitializeFactory(IRepositoryFactory factory)
    {
      m_currentFactory = factory;
    }

    public static IGameRepository GetGameRepository()
    {
      if (m_currentFactory == null)
        throw new InvalidOperationException(
          GameDataMessages.FactoryNotInitializedError);

      return m_currentFactory.GetGameRepository();
    }
  }
}
