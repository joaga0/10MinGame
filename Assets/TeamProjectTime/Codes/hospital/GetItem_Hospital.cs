using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem_Hospital : MonoBehaviour
{
    public ItemUI_Hospital ItemUIScript;
    public int Getid;

    public void Get()
    {
        ItemUIScript.ActiveItemUI(Getid);
    }
    public void Put()
    {
        ItemUIScript.ActiveItemUIFalse(Getid);
    }

    public void ChangeWateringpot()
    {
        ItemUIScript.ActiveItemUIFalse(2);
        ItemUIScript.ActiveItemUI(0);
    }
}
