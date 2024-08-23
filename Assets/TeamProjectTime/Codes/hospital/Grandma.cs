using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma : MonoBehaviour
{
    public GameObject endingpanel;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(ending());
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(2f); 
        endingpanel.SetActive(true);
    }
}
