using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public ItemUI ItemUIScript;
    public int Getid;

    public void Get()
    {
        ItemUIScript.ActiveItemUI(Getid);
    }
}
