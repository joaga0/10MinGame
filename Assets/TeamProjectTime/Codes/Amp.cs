using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amp : MonoBehaviour
{
    private GuitarGameManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<GuitarGameManager>();
    }

    // Update is called once per frame
    public void music_On()
    {
        musicManager.start_music();
    }
}
