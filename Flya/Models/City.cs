using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace Flya.Models
{

  public class City
  {
    private string _city;
    private string _state;
    private int _id;

    public City(string city, string state, int id = 0)
    {
      _city = city;
      _state = state;
      _id = id;
    }

    public string GetCity()
    {
      return _city;
    }

    public string GetState()
    {
      return _state;
    }

    public string GetCityState()
    {
      return _city + ", " + _state;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cities;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherCity)
    {
      if (!(otherCity is City))
      {
        return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool cityEquality = (this.GetCity() == newCity.GetCity());
        bool stateEquality = (this.GetState() == newCity.GetState());
        return (cityEquality && stateEquality);
      }
    }

  }
}
