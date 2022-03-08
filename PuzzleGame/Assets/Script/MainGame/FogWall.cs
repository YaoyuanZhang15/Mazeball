using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWall : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //gameObject.SetActive(false);
            StartCoroutine(FogEvanish());
        }
    }

    IEnumerator FogEvanish()
    {
        for(int i = 0; i <= 8; i++)
        {
            
            Color32 c = gameObject.GetComponent<SpriteRenderer>().color;
            byte k = (byte)(c.a - 20 * i);
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(c.r, c.g, c.b, k );
            Debug.Log("r " + c.r + " g " + c.g + " b " + c.b + " a " + c.a + " k: " + k);
            yield return new WaitForSeconds(0.2f);
            
        }
        gameObject.SetActive(false);

    }
        
}
