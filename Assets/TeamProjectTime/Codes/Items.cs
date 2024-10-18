using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public Sprite newSprite;
    SpriteRenderer spriter;
    private Sprite originalSprite;
    public float ChangeDuration;
    public bool Required = true;
    public int Id;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        originalSprite = spriter.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Required == false)
        {
            StartCoroutine(ChangeSpriteTemp());
        }

    }

    IEnumerator ChangeSpriteTemp()
    {
        Required = true;
        spriter.sprite = newSprite;
        yield return new WaitForSeconds(ChangeDuration);
        spriter.sprite = originalSprite;
    }
}
