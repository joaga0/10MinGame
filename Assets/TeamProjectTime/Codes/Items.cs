using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public Sprite newSprite;
    SpriteRenderer spriter;
    private Sprite originalSprite;
    public float ChangeDuration;
    public bool Changed = false;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        originalSprite = spriter.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))  // X키를 눌렀을 때
        {
            if (Changed == false)
            {
                StartCoroutine(ChangeSpriteTemp());
            }
            
        }
    }

    IEnumerator ChangeSpriteTemp()
    {
        Changed = true;
        spriter.sprite = newSprite;
        yield return new WaitForSeconds(ChangeDuration);
        spriter.sprite = originalSprite;
        Changed = false;
    }
}
