
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using Flya.Models;

namespace Flya.Tests
{
  [TestClass]
  public class CityTest : IDisposable
  {
    public void Dispose()
    {
      City.ClearAll();
    }

    public CityTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=flya_test;";
    }

    [TestMethod]
    public void GetCityState_ReturnsCityAndStateName_String()
    {
      string expectedName = "Boston, MA";

      City newCity = new City("Boston", "MA");
      string fullName = newCity.GetCityState();

      Assert.AreEqual(expectedName, fullName);
    }

  }
}
