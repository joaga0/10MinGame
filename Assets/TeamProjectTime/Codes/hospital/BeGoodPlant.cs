using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGoodPlant : MonoBehaviour
{
    public GameObject good_plant;
    public GameObject before_text;
    public GameObject after_text;
    private bool hasPlayed = false;

    void Update(){
        if(PlayerHospital.watered == true && !hasPlayed){
            GetComponent<AudioSource>().Play();
            StartCoroutine(growing());
            hasPlayed = true;
        }
    }

    IEnumerator growing()
    {
        yield return new WaitForSeconds(5f); 
        good_plant.SetActive(true);
        before_text.SetActive(false);
        after_text.SetActive(true);
        gameObject.SetActive(false);
    }
}
