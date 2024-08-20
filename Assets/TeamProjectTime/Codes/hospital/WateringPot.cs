using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringPot : MonoBehaviour
{
    public GameObject over_pot;
    public GameObject full_pot;
    public GameObject empty_pot;
    public GameObject water;
    public ItemUI_Hospital ItemUIScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WaterTimer.watering_time > 250 && full_pot.activeSelf == false){
            full_pot.SetActive(true);
            empty_pot.SetActive(false);
            ItemUIScript.ActiveItemUI(2);
            ItemUIScript.ActiveItemUIFalse(0);
        }
        if(WaterTimer.watering_time > 280 && water.activeSelf == true){
            over_pot.SetActive(true);
        }
        else if(full_pot.activeSelf == true && water.activeSelf == false){
            over_pot.SetActive(false);
        }
    }
}
