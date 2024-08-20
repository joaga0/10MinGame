using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amp : MonoBehaviour
{
    private GuitarGameManager musicManager;
    
    public Image buttonImage;
    public Sprite turnOn;
    public Sprite turnOff;
    

    // Start is called before the first frame update
    void Start()
    {
        musicManager = FindObjectOfType<GuitarGameManager>();
    }

    // Update is called once per frame
    public void music_On()
    {
        if (!musicManager.ampOn)
        {
            musicManager.start_music();
            musicManager.ampOn = true;
            buttonImage.sprite = turnOn;
        }
        else
        {
            musicManager.stop_music();
            musicManager.ampOn = false;
            buttonImage.sprite = turnOff;
        }
    }
}
