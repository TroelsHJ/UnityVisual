using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class DatabaseHandler : MonoBehaviour
{
    private string connectionString;
    private MySqlConnection conn;
    private MySqlDataReader reader;
    private MySqlCommand cmd;

    //private void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //    connectionString = "server=sql.itcn.dk;uid=troe3894.EADANIA;pwd=d8QPTq33f6;database=troe3894.EADANIA";

    //    cmd = new MySqlCommand();

    //    try
    //    {
    //        conn = new MySqlConnection();
    //        conn.ConnectionString = connectionString;
    //        conn.Open();
    //    }
    //    catch (System.Exception e)
    //    {
    //        Debug.Log(e);
    //    }

    //    Debug.Log(conn.State);
    //}

    public int GetListForArea(int _postalNumber)
    {
        List<WaitList> _tempList = new List<WaitList>();
        int totalListLength = 0;

        _tempList = GetListFromDB(_postalNumber);

        _tempList = FilterListEntries(_tempList);

        foreach (WaitList item in _tempList)
        {
            totalListLength += item.ListLength;
        }

        return totalListLength;
    }

    private List<WaitList> GetListFromDB(int _postalNumber)
    {
        List<WaitList> _tempList = new List<WaitList>();
        WaitList _tempListObj;

        cmd.CommandText = string.Format("SELECT ventelister.AntalPaaVenteliste, afdelinger.AfdPostBy, afdelinger.AfdId FROM ventelister INNER JOIN afdelinger ON ventelister.FK_AfdId = afdelinger.AfdId WHERE AfdPostBy = {0};", _postalNumber);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            _tempListObj = new WaitList((int)reader[2], (int)reader[1], (int)reader[0]);
            _tempList.Add(_tempListObj);
        }
        reader.Close();

        return _tempList;
    }

    private List<WaitList> FilterListEntries(List<WaitList> _tempList)
    {
        WaitList[] _tempAry = _tempList.ToArray();
        Dictionary<int, int> _tempListDictonary = new Dictionary<int, int>();
        Dictionary<int, int> _tempCountDictonary = new Dictionary<int, int>();

        List<WaitList> _finalList = new List<WaitList>();

        _tempCountDictonary = CountDepartmentOccu(_tempAry);

        _tempListDictonary = AddListsPrDeparment(_tempAry);

        _tempListDictonary = DivListPrDepartmentOccu(_tempListDictonary, _tempCountDictonary);

        foreach (KeyValuePair<int, int> item in _tempListDictonary)
        {
            _finalList.Add(new WaitList(_tempAry[0].PostalCode, item.Key, item.Value));
        }

        return _finalList;
    }

    private Dictionary<int, int> CountDepartmentOccu(WaitList[] _tempAry)
    {
        Dictionary<int, int> _tempCountDictonary = new Dictionary<int, int>();

        for (int j = 0; j < _tempAry.Length; j++)
        {
            if (_tempCountDictonary.ContainsKey(_tempAry[j].Department))
            {
                _tempCountDictonary[_tempAry[j].Department] += 1;
            }
            else
            {
                _tempCountDictonary.Add(_tempAry[j].Department, 1);
            }
        }

        return _tempCountDictonary;

    }

    private Dictionary<int, int> AddListsPrDeparment(WaitList[] _tempAry)
    {
        Dictionary<int, int> _tempListDictonary = new Dictionary<int, int>();

        for (int i = 0; i < _tempAry.Length; i++)
        {
            if (_tempListDictonary.ContainsKey(_tempAry[i].Department))
            {
                _tempListDictonary[_tempAry[i].Department] += _tempAry[i].ListLength;
            }
            else
            {
                _tempListDictonary.Add(_tempAry[i].Department, _tempAry[i].ListLength);
            }
        }

        return _tempListDictonary;
    }

    private Dictionary<int, int> DivListPrDepartmentOccu(Dictionary<int, int> _tempListDictonary, Dictionary<int, int> _tempCountDictonary)
    {
        foreach (KeyValuePair<int, int> item in _tempCountDictonary)
        {
            _tempListDictonary[item.Key] /= _tempCountDictonary[item.Key];
        }

        return _tempListDictonary;
    }

}
