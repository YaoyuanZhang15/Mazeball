using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    public List<Sprite> spriteList;
    Image currSprite;
    float timeRemind = 0f;
    int i;

    void Awake()
    {
        i = 0;
        currSprite = gameObject.GetComponent<Image>();
        currSprite.sprite = spriteList[i];

    }

    void Update()
    {
        if (timeRemind < 0.1f)
        {

            timeRemind += Time.deltaTime;

        }
        else
        {
            timeRemind = 0;
            i += 1;
            if (i >= spriteList.Count)
            {
                i = 0;
            }
            currSprite.sprite = spriteList[i];

        }

    }

}
