using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public GameObject[] itemUIs;

    // Start is called before the first frame update
    public void ActiveItemUI(int id)
    {
        itemUIs[id].SetActive(true);
    }
}
