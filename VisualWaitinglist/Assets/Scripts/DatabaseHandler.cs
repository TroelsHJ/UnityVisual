using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System;

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
        List<WaitList> _tempList = new List<WaitList>();
        WaitList _tempListObj;
        int totalListLength = 0;


        // Husk at tilføje afdeling til query!!
        cmd.CommandText = string.Format("SELECT ventelister.AntalPaaVenteliste, afdelinger.AfdPostBy FROM ventelister INNER JOIN afdelinger ON ventelister.FK_AfdId = afdelinger.AfdId WHERE AfdPostBy = {0};", _postalNumber);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            _tempListObj = new WaitList((int)reader[2], (int)reader[1], (int)reader[0]);
            _tempList.Add(_tempListObj);
        }
        reader.Close();

        _tempList = FilterListEntries(_tempList);
        foreach (WaitList item in _tempList)
        {
            totalListLength += item.ListLength;
        }

        return totalListLength;
    }

    private List<WaitList> FilterListEntries(List<WaitList> _tempList)
    {
        WaitList[] _tempAry = _tempList.ToArray();

        for (int i = 0; i < _tempAry.Length; i++)
        {
            if (_tempAry[i].Department == _tempAry[i + 1].Department)
            {

            }
        }

        return null;
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
