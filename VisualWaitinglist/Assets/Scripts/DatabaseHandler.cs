using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseHandler : MonoBehaviour
{
    private string connectionString;
    private MySqlConnection conn;
    private MySqlDataReader reader;
    private MySqlCommand cmd;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        connectionString = "server=sql.itcn.dk;uid=troe3894.EADANIA;pwd=d8QPTq33f6;database=troe3894.EADANIA";

        cmd = new MySqlCommand();

        try
        {
            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            conn.Open();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

        Debug.Log(conn.State);
    }

    public int GetSizeOfList(int _postalNumber)
    {
        //List<PostalArea> _tempList = new List<PostalArea>();
        //PostalArea tempArea;
        int numberOnLists = 0;

        cmd.CommandText = string.Format("SELECT ventelister.AntalPaaVenteliste, afdelinger.AfdPostBy FROM ventelister INNER JOIN afdelinger ON ventelister.FK_AfdId = afdelinger.AfdId WHERE AfdPostBy = {0};", _postalNumber);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            numberOnLists += (int)reader[0];
            //tempArea = new PostalArea();
            //tempArea.SizeOfList = (int)reader[0];
            //tempArea.PostalCode = (int)reader[1];
            //_tempList.Add(tempArea);
        }
        reader.Close();

        return numberOnLists;
    }

    //public List<Bil> GetSomethingOnList()
    //{
    //    List<Bil> _tempCarList = new List<Bil>();
    //    Bil _tempCar = new Bil();
    //    cmd.CommandText = string.Format("SELECT * FROM cars WHERE ManufacturedYear = '{0}'", _year);
    //    cmd.CommandType = CommandType.Text;
    //    cmd.Connection = conn;

    //    reader = cmd.ExecuteReader();
    //    while (reader.Read())
    //    {
    //        _tempCar.ID = (int)reader[0];
    //        _tempCar.Manufacture = (string)reader[1];
    //        _tempCar.ManufacturedYear = (int)reader[2];
    //        _tempCarList.Add(_tempCar);
    //    }

    //    reader.Close();
    //    return _tempCarList;
    //}
}
