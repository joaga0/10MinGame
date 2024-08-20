using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarGameManager : MonoBehaviour
{
    public bool havingGuitar;
    public bool ampOn;
    public bool connectCable;
    public Image guitar_image;
    public Image open_amp;
    public GameObject guitar_stand;
    public GameObject stand;
    private Music musicManager;

    public GameObject[] musics;
    GameObject[] music_effect = new GameObject[6];
    
    void Start()
    {
        havingGuitar = false;
        ampOn = false;
        connectCable = false;
        guitar_image.gameObject.SetActive(false);
        musicManager = FindObjectOfType<Music>();
    }

    public void Get_Guitar()
    {
        havingGuitar = true;
        guitar_image.gameObject.SetActive(true);
        guitar_stand.SetActive(false);
        stand.SetActive(true);
    }

    public void Open_Amp()
    {
        open_amp.gameObject.SetActive(true);
    }

    public void start_music()
    {
        StartCoroutine("left_music");
    }

    public IEnumerator left_music()
    {
        while(true)
        {
            for (int i = 0; i < 6; i++)
            {
                music_effect[i] = Instantiate(musics[i]);
                yield return new WaitForSeconds(0.4f);
                Destroy(music_effect[i], 7.0f);
            }
            yield return new WaitForSeconds(5.0f);
        }
    }
}