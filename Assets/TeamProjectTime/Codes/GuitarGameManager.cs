using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuitarGameManager : MonoBehaviour
{
    public bool havingGuitar;
    public bool ampOn;
    public bool connectCable;
    public Image open_amp;
    public Image open_cable;
    public GameObject guitar_stand;
    public GameObject stand;
    private Music musicManager;
    private GuitarPlayer guitarplayer;

    public GameObject[] musics;
    GameObject[] music_effect = new GameObject[6];
    
    void Start()
    {
        havingGuitar = false;
        ampOn = false;
        connectCable = false;
        musicManager = FindObjectOfType<Music>();
        guitarplayer = FindObjectOfType<GuitarPlayer>();
    }

    public void Get_Guitar()
    {
        havingGuitar = true;
        //guitar_image.gameObject.SetActive(true);
        guitar_stand.SetActive(false);
        stand.SetActive(true);
        guitarplayer.get_Guitar();
    }

    public void Open_Amp()
    {
        open_amp.gameObject.SetActive(true);
    }

    public void Open_Cable()
    {
        if (havingGuitar && ampOn)
            open_cable.gameObject.SetActive(true);
        else
            Debug.Log("이전 단계를 먼저 끝내야합니다.");
    }

    public void start_music()
    {
        StartCoroutine("left_music");
    }

    public void stop_music()
    {
        StopCoroutine("left_music");
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