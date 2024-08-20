using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGoodPlant : MonoBehaviour
{
    public GameObject good_plant;
    public GameObject before_text;
    public GameObject after_text;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update(){
        if(PlayerHospital.watered==true){
            StartCoroutine(growing());
        }
    }

    IEnumerator growing()
    {
        yield return new WaitForSeconds(1.5f); 
        good_plant.SetActive(true);
        before_text.SetActive(false);
        after_text.SetActive(true);
        gameObject.SetActive(false);
    }
}
