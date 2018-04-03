using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class DatabaseHandler : MonoBehaviour
{
    private string ConnectionString;
    private MySqlConnection Conn;
    private MySqlDataReader Reader;
    private MySqlCommand CMD;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        ConnectionString = "server=sql.itcn.dk;uid=troe3894.EADANIA;pwd=d8QPTq33f6;database=troe3894.EADANIA";

        CMD = new MySqlCommand();

        try
        {
            Conn = new MySqlConnection();
            Conn.ConnectionString = ConnectionString;
            Conn.Open();
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }

        Debug.Log(Conn.State);
    }

    internal string GetNameForArea(int _postalNumber)
    {
        string _tempPostalName = "";

        CMD.CommandText = string.Format("SELECT * FROM omraadenavn WHERE AfdId = {0};", _postalNumber);
        CMD.CommandType = CommandType.Text;
        CMD.Connection = Conn;

        Reader = CMD.ExecuteReader();
        while (Reader.Read())
        {
            _tempPostalName = Reader[1].ToString();
        }
        Reader.Close();

        return _tempPostalName;
    }

    internal int GetListForArea(int _postalNumber)
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

        CMD.CommandText = string.Format("SELECT ventelister.AntalPaaVenteliste, afdelinger.AfdPostBy, afdelinger.AfdId FROM ventelister INNER JOIN afdelinger ON ventelister.FK_AfdId = afdelinger.AfdId WHERE AfdPostBy = {0};", _postalNumber);
        CMD.CommandType = CommandType.Text;
        CMD.Connection = Conn;

        Reader = CMD.ExecuteReader();
        while (Reader.Read())
        {
            _tempListObj = new WaitList((int)Reader[2], (int)Reader[1], (int)Reader[0]);
            _tempList.Add(_tempListObj);
        }
        Reader.Close();

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
