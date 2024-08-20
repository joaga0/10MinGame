using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject[] musics;
    GameObject[] music_effect = new GameObject[6];

    void Start()
    {
        StartCoroutine("right_music");
    }

    IEnumerator right_music()
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
