using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Server.DatabaseManager;

namespace Server.Controllers
{
    public class FelhasznalokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok ORDER BY Nev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Felhasznalo egyFelhasznalo = new Felhasznalo();
                    egyFelhasznalo.Id = int.Parse(reader["Id"].ToString());
                    egyFelhasznalo.LoginNev = reader["LoginNev"].ToString();
                    egyFelhasznalo.HASH = reader["HASH"].ToString();
                    egyFelhasznalo.SALT = reader["SALT"].ToString();
                    egyFelhasznalo.Nev = reader["Nev"].ToString();
                    egyFelhasznalo.Jog = byte.Parse(reader["Jog"].ToString());
                    egyFelhasznalo.Aktiv = bool.Parse(reader["Aktiv"].ToString().ToLower());
                    egyFelhasznalo.Email = reader["Email"].ToString();
                    egyFelhasznalo.ProfilKep = reader["ProfilKep"].ToString();
                    list.Add(egyFelhasznalo);
                }
            }
            catch (Exception ex) 
            {
                Felhasznalo felhasznalo = new Felhasznalo();
                felhasznalo.Id = -1;
                felhasznalo.Nev = ex.Message;
                list.Add (felhasznalo);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public int Insert(Record record)
        {
            return 0;
        }

        public int Update(Record record)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}