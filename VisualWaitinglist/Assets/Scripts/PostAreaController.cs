using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAreaController : MonoBehaviour
{
    DatabaseHandler DB;
    private int amountWaiting;
    public ShowData showData;

    void Start()
    {
        DB = GameObject.Find("DatabaseHandler").GetComponent<DatabaseHandler>();
    }

    private void OnMouseOver()
    {
        amountWaiting = DB.GetListForArea(int.Parse(this.transform.name));
        Debug.Log(amountWaiting);
        showData.DisplayAmountWaitingInInfoBox(amountWaiting);
    }

    private void OnMouseExit()
    {
        showData.DisplayAmountWaitingInInfoBox(0);
    }

}
