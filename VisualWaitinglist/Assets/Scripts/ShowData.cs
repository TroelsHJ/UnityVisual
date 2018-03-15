using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{

    DatabaseHandler DB;
    public Text displayTextField;
    private int numberToDisplay;

    void Start()
    {
        DB = GameObject.Find("DatabaseHandler").GetComponent<DatabaseHandler>();
    }

    public void BtnListOf8000()
    {
        numberToDisplay = DB.GetSizeOfList(8000);
        Display(numberToDisplay);
    }

    //public void BtnGetCarOnYear()
    //{
    //    List<Bil> _tempList = new List<Bil>();
    //    _tempList = DB.GetCarOnYear(int.Parse(inputTextField.text));
    //    Display(_tempList);
    //}

    //public void BtnSaveCar()
    //{
    //    Bil _tempCar = new Bil();

    //    string[] tempSting = inputTextField.text.Split(',');

    //    _tempCar.Manufacture = tempSting[0];
    //    _tempCar.ManufacturedYear = int.Parse(tempSting[1]);

    //    DB.UpdateCar(car.ID, _tempCar);

    //}

    //public void BtnCreateCar()
    //{
    //    Bil _tempCar = new Bil();

    //    string[] tempSting = inputTextField.text.Split(',');

    //    _tempCar.Manufacture = tempSting[0];
    //    _tempCar.ManufacturedYear = int.Parse(tempSting[1]);

    //    DB.CreateCar(_tempCar);
    //}

    //public void BtnDeleteCar()
    //{
    //    DB.DeleteCar(int.Parse(inputTextField.text));
    //    Display("Bilen er slettet");
    //}

    //private void Display(Bil _car)
    //{
    //    displayTextField.text = _car.Manufacture + ", " + _car.ManufacturedYear;
    //}

    //private void Display(List<Bil> _carList)
    //{
    //    foreach (Bil item in _carList)
    //    {
    //        displayTextField.text += item.Manufacture + ", " + item.ManufacturedYear + "\n";
    //    }
    //}
    private void Display(int? _numberToDisplay)
    {
        if (_numberToDisplay == null)
        {
            displayTextField.text = "Der er sq ikke lige noget at vise";
        }
        else
        {
            displayTextField.text = _numberToDisplay.ToString();
        }
    }
}
