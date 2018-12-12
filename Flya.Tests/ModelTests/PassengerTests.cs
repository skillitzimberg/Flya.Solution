
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using Flya.Models;

namespace Flya.Tests
{
  [TestClass]
  public class PassengerTest
  {
    [TestMethod]
    public void GetFullName_ReturnsFullName_String()
    {
      string expectedName = "Scott Bergler";

      Passenger newPassenger = new Passenger("Scott", "Bergler");
      string fullName = newPassenger.GetFullName();

      Assert.AreEqual(expectedName, fullName);
    }

  }
}
