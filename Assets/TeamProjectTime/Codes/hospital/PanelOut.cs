using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOut : MonoBehaviour
{
    public GameObject panel;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closePanel()
    {
        panel.SetActive(false);
        water.SetActive(false);
        SinkValve.valve_count = 0;
        PlayerHospital.panelOn = false;
    }

}
