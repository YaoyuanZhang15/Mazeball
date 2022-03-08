using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    public float degreesPerSec = 36f;

    //public int movementMode = 0;

    public float speed = 10;

    public GameObject playerBall, collection1, collection2, collection3;

    private Vector3 targetPos;
    private float camRangeX = 3;
    private float camRangeY = 1.5f;

    //private bool isMoving;

    public GameObject turnBase;


    private void Start()
    {
        
        GameSceneController.Instance.collection1 = collection1;
        GameSceneController.Instance.collection2 = collection2;
        GameSceneController.Instance.collection3 = collection3;

        //camFixX = playerBall.transform.position.x - 0;
        //camFixY = playerBall.transform.position.y - 0;

        targetPos = new Vector3(0, 0, -10);

    }

    private void Update()
    {

        CameraMovement();
        Movement2D();
        

    }

    private void Movement2D()
    {

        float curRot = turnBase.transform.localRotation.eulerAngles.z;
        if (Input.GetKey(KeyCode.A))
        {
            float rotAmount = degreesPerSec * Time.deltaTime;

            turnBase.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            float rotAmount = -degreesPerSec * Time.deltaTime;

            turnBase.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }

        
    }

    private void CameraMovement()
    {
        float camCurrX = playerBall.transform.position.x - targetPos.x;
        float camCurrY = playerBall.transform.position.y - targetPos.y;

        //if (camCurrX - camFixX > camRangeX)
        if (camCurrX  > camRangeX)
        {
            targetPos += new Vector3(1, 0, 0);

        }
        if (camCurrX < -camRangeX)
        {
            targetPos += new Vector3(-1, 0, 0);

        }

        //if (camCurrY - camFixY > camRangeY)
        if (camCurrY > camRangeY)
        {
            targetPos += new Vector3(0, 1, 0);

        }
        if (camCurrY < -camRangeY)
        {
            targetPos += new Vector3(0, -1, 0);

        }
        
        CameraBehaviour.Instance.transform.position = Vector3.LerpUnclamped(CameraBehaviour.Instance.transform.position, targetPos, Time.deltaTime);

    }


}
