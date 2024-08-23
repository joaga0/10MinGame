using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetOut : MonoBehaviour
{
    public GameObject panel;
    public GameObject targetCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetCanvas.SetActive(true);
    }

    public void closePanel()
    {
        panel.SetActive(false);
    }

}
