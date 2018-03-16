using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Text displayTextField;

    public void DisplayAmountWaitingInInfoBox(int _numberToDisplay)
    {
        displayTextField.text = _numberToDisplay.ToString();
    }
}
