using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBehaviour : Singleton <CameraBehaviour>
{
    public Camera cam;
    
    public float sensitivity = 0.5f;
    public float speed = 10;

    public bool movementLock;

    
    
    private void Start()
    {
        
        cam = gameObject.GetComponent<Camera>();
        InitialCamera();
    }

    

    public void InitialCamera()
    {
        gameObject.transform.position = new Vector3(0, 0, -10);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        movementLock = true;


    }

   
}
