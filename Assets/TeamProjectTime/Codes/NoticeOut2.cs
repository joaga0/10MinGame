using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeOut2 : MonoBehaviour

{
    public GameObject panel;
    public GameObject oldobject;
    public GameObject newobject;
    public GameObject myfriend;
    public GameObject ending;
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
        oldobject.SetActive(false);
        newobject.SetActive(true);
        panel.SetActive(false);
        myfriend.SetActive(true);
        ending.SetActive(true);
    }

}
