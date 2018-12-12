using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace Flya.Models
{

  public class Passenger
  {
    private string _firstName;
    private string _lastName;
    private int _id;

    public Passenger(string firstName, string lastName, int id = 0)
    {
      _firstName = firstName;
      _lastName = lastName;
      _id = id;
    }

    public string GetFirstName()
    {
      return _firstName;
    }

    public string GetLastName()
    {
      return _lastName;
    }

    public string GetFullName()
    {
      return _firstName + " " + _lastName;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM passengers;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherPassenger)
    {
      if (!(otherPassenger is Passenger))
      {
        return false;
      }
      else
      {
        Passenger newPassenger = (Passenger) otherPassenger;
        bool firstNameEquality = (this.GetFirstName() == newPassenger.GetFirstName());
        bool lastNameEquality = (this.GetLast() == newPassenger.GetLast());
        return (firstNameEquality && lastNameEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO passengers (first_name, last_name, phone_number, stylist_id) VALUES (@ClientFirstName, @ClientLastName, @ClientPhoneNumber, @StylistId);";

      MySqlParameter passengerFirstName = new MySqlParameter();
      passengerFirstName.ParameterName = "@ClientFirstName";
      passengerFirstName.Value = this._firstName;
      cmd.Parameters.Add(passengerFirstName);

      MySqlParameter passengerLastName = new MySqlParameter();
      passengerLastName.ParameterName = "@ClientLastName";
      passengerLastName.Value = this._lastName;
      cmd.Parameters.Add(passengerLastName);

      MySqlParameter passengerPhoneNumber = new MySqlParameter();
      passengerPhoneNumber.ParameterName = "@ClientPhoneNumber";
      passengerPhoneNumber.Value = this._phoneNumber;
      cmd.Parameters.Add(passengerPhoneNumber);

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@StylistId";
      stylistId.Value = this._stylistId;
      cmd.Parameters.Add(stylistId);

      //Add this command for above 3 lines of code
      cmd.Parameters.AddWithValue("@ClientFirstName", this._firstName);
      cmd.Parameters.AddWithValue("@ClientLastName", this._lastName);
      cmd.Parameters.AddWithValue("@ClientPhoneNumber", this._phoneNumber);
      cmd.Parameters.AddWithValue("@StylistId", this._stylistId);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
