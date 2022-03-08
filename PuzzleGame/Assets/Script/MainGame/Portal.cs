using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal exit;
    public bool tpLock;

    private void Start()
    {
        tpLock = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tpLock)
        {
            exit.tpLock = false;
            collision.gameObject.transform.position = exit.transform.position;
            tpLock = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tpLock = true;
    }

}
