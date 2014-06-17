using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfDrones.Data.Tests
{
  [TestClass]
  public class RepositoryFactoryTest
  {
    [TestInitialize]
    public void SetUp()
    {
      RepositoryFactory.InitializeFactory(null);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void GetGameRepository_NotInitialized_InvalidOperationException()
    {
      //Act
      RepositoryFactory.GetGameRepository();
    }
  }
}
