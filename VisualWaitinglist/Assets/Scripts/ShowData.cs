using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public Text DisplayWaitlistAmountField;
    public Text DisplayAreaCodeField;
    public Text DisplayAreaNameField;
    public GameObject InfoBoxArea;
    public GameObject HelpInfoBoxArea;
    public GameObject AboutInfoBoxArea;

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

    public void BtnHelp()
    {
        InfoBoxArea.SetActive(false);
        HelpInfoBoxArea.SetActive(true);
    }

    public void BtnCloseHelp()
    {
        InfoBoxArea.SetActive(true);
        HelpInfoBoxArea.SetActive(false);
    }

    public void BtnAbout()
    {
        InfoBoxArea.SetActive(false);
        AboutInfoBoxArea.SetActive(true);
    }

    public void BtnCloseAbout()
    {
        InfoBoxArea.SetActive(true);
        AboutInfoBoxArea.SetActive(false);
    }

}
