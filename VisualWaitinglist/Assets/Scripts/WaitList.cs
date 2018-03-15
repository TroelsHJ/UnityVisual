using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitList
{
    public int PostalCode { get; set; }
    public int Department { get; set; }
    public int ListLength { get; set; }

    public WaitList(int _depNumber, int _postalCode, int _listLength)
    {
        PostalCode = _postalCode;
        Department = _depNumber;
        ListLength = _listLength;
    }

}
