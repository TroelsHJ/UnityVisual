using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Text DisplayWaitlistAmountField;
    public Text DisplayAreaCodeField;
    public Text DisplayAreaNameField;

    public void DisplayInInfoBox(int _numberToDisplay, string _postalName, string _postalNumber)
    {
        DisplayWaitlistAmountField.text = _numberToDisplay.ToString();
        DisplayAreaCodeField.text = _postalNumber;
        DisplayAreaNameField.text = _postalName;
    }

    public void ClearDisplayInfoBox()
    {
        DisplayWaitlistAmountField.text = "";
        DisplayAreaCodeField.text = "";
        DisplayAreaNameField.text = "";
    }

}
