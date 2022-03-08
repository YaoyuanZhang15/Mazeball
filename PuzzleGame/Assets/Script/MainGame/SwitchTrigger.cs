using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{

    public GameObject blockObject;
    public SwitchTrigger anotherSwitch;
    public bool isTurnOn;
    public int transformMode, currState;

    [SerializeField]
    private Sprite imageOn, imageOff;
    [SerializeField]
    private List <Vector3> targetList;

    public float speed = 1;

    private void Update()
    {
        
        if (transformMode == 0)
        {
            MovementEvent();
        }
        if(transformMode == 1)
        {
            RotationEvent();
        }
        if (transformMode == 2)
        {
            ScaleEvent();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTurnOn)
        {
            ChangeState();
            gameObject.GetComponent<SpriteRenderer>().sprite = imageOn;

            if (anotherSwitch != null)
            {
                anotherSwitch.isTurnOn = true;
            }
            isTurnOn = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
 
        gameObject.GetComponent<SpriteRenderer>().sprite = imageOff;
        if (anotherSwitch != null)
        {
            anotherSwitch.isTurnOn = false;
        }
        isTurnOn = false;

    }

    private void ChangeState()
    {
        
        if (blockObject.transform.localPosition == targetList[currState])
        {
            
        }
        if (currState < targetList.Count - 1)
        {
            currState++;
        }
        else
        {
            currState = 0;
        }

        if (anotherSwitch != null)
        {
            anotherSwitch.currState = currState;
        }

    }

    private void MovementEvent()
    {
        blockObject.transform.localPosition = Vector3.MoveTowards(blockObject.transform.localPosition, targetList[currState], speed * Time.deltaTime);
        
    }

    private void RotationEvent()
    {
        
        Quaternion rot = Quaternion.Euler(targetList[currState].x, targetList[currState].y, targetList[currState].z);
        blockObject.transform.localRotation = Quaternion.RotateTowards(blockObject.transform.localRotation, rot, speed * 20 * Time.deltaTime);
    }

    private void ScaleEvent()
    {
        Debug.Log("Scale is not done yet, currState: " + currState);
    }
}
