using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAreaController : MonoBehaviour
{
    private ShowData Display;
    private DatabaseHandler DB;
    public int AmountWaiting;
    private string PostalAreaName;

    void Start()
    {
        DB = GameObject.Find("DatabaseHandler").GetComponent<DatabaseHandler>();
        Display = GameObject.Find("Canvas").GetComponent<ShowData>();

        AmountWaiting = DB.GetListForArea(int.Parse(this.transform.name));
        PostalAreaName = DB.GetNameForArea(int.Parse(this.transform.name));
        //AmountWaiting = int.Parse(this.transform.name);
        //PostalAreaName = this.transform.name;

        SetInitScale(AmountWaiting);
    }

    private void SetInitScale(int _amountWaiting)
    {
        float _scaleByAmount = _amountWaiting * 0.001f;
        this.transform.localScale += new Vector3(0, _scaleByAmount, 0);
        this.transform.position += new Vector3(0, _scaleByAmount / 2, 0);
    }

    private void OnMouseOver()
    {
        Display.DisplayInInfoBox(AmountWaiting, PostalAreaName, this.transform.name);
    }

    private void OnMouseExit()
    {
        Display.ClearDisplayInfoBox();
    }

}
