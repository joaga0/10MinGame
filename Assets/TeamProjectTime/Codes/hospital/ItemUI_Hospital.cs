using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI_Hospital : MonoBehaviour
{
    public GameObject[] itemUIs;
    public static bool[] inventory = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<3; i++){
            inventory[i]=false;
        }
    }
    public void ActiveItemUI(int id)
    {
        itemUIs[id].SetActive(true);
        inventory[id]=true;
    }
    public void ActiveItemUIFalse(int id)
    {
        itemUIs[id].SetActive(false);
        inventory[id]=false;
    }
}
