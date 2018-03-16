using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAreaController : MonoBehaviour
{
    DatabaseHandler DB;
    private int amountWaiting;
    public ShowData display;

    void Start()
    {
        DB = GameObject.Find("DatabaseHandler").GetComponent<DatabaseHandler>();

        //amountWaiting = DB.GetListForArea(int.Parse(this.transform.name));
        amountWaiting = int.Parse(this.transform.name);

        SetInitScale(amountWaiting);
    }

    private void SetInitScale(int amountWaiting)
    {
        float scaleByAmount = amountWaiting / 50;
        this.transform.localScale += new Vector3(5, scaleByAmount, 5);
        this.transform.position += new Vector3(0, scaleByAmount / 2, 0);
    }

    private void OnMouseOver()
    {
        display.DisplayAmountWaitingInBox(amountWaiting);
    }

    private void OnMouseExit()
    {
        display.ClearDisplayAmountWaitingInBox();
    }

}
