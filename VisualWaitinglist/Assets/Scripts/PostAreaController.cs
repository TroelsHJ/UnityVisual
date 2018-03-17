using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAreaController : MonoBehaviour
{
    DatabaseHandler DB;
    public ShowData display;

    private int amountWaiting;
    private Renderer ColorRenderer;

    void Start()
    {
        DB = GameObject.Find("DatabaseHandler").GetComponent<DatabaseHandler>();
        ColorRenderer = GetComponent<Renderer>();

        //amountWaiting = DB.GetListForArea(int.Parse(this.transform.name));
        amountWaiting = int.Parse(this.transform.name);

        SetInitScale(amountWaiting);
        SetRandomColor();

        //SetColorGradient();
    }

    private void SetRandomColor()
    {
        ColorRenderer.material.color = UnityEngine.Random.ColorHSV();
    }

    private void SetColorGradient()
    {
        Gradient g = new Gradient();
        GradientColorKey[] gck = new GradientColorKey[2];
        GradientAlphaKey[] gak = new GradientAlphaKey[2];

        gck[0].color = Color.red;
        gck[0].time = 0.0F;
        gck[1].color = Color.blue;
        gck[1].time = 1.0F;

        gak[0].alpha = 1.0F;
        gak[0].time = 0.0F;
        gak[1].alpha = 0.0F;
        gak[1].time = 1.0F;

        g.SetKeys(gck, gak);
        this.gameObject.GetComponent<Renderer>().material.color = g.Evaluate(1);
        Debug.Log(g.Evaluate(0.25F));
    }

    private void SetInitScale(int amountWaiting)
    {
        float scaleByAmount = amountWaiting * 0.1f;
        this.transform.localScale += new Vector3(0, scaleByAmount, 0);
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
