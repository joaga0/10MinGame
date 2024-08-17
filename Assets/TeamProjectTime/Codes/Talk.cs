using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour
{
    public GameObject playerCanvas;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //playerCanvas.SetActive(!playerCanvas.activeSelf);
        }
    }
}
