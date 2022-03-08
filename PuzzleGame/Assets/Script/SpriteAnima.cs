using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnima : MonoBehaviour
{
    public List<Sprite> spriteList;
    SpriteRenderer currSprite;
    //float timeRemind = 0f;
    public bool isLoop;
    int i;

    void Awake()
    {
        i = 0;
        currSprite = gameObject.GetComponent<SpriteRenderer>();
        currSprite.sprite = spriteList[i];
        if (isLoop)
        {
            StartCoroutine(LoopAnimation());
        }
        else
        {
            StartCoroutine(OnceAnimation());
        }
    }

    IEnumerator LoopAnimation()
    {
        i += 1;
        if (i >= spriteList.Count)
        {
            i = 0;
        }
        currSprite.sprite = spriteList[i];
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoopAnimation());
    }

    IEnumerator OnceAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        i += 1;
        if (i >= spriteList.Count)
        {
            i = 0;
            gameObject.SetActive(false);
        }
        else
        {
            currSprite.sprite = spriteList[i];
            StartCoroutine(OnceAnimation());
        }

    }
    public void ResetLoop()
    {
        //StopAllCoroutines();
        i = 0;
        //currSprite.sprite = spriteList[i];
        //StartCoroutine(LoopAnimation());
    }
    public void PlayOnce()
    {
        gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(OnceAnimation());
    }

}
