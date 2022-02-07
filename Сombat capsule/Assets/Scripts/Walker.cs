using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right,
}

public class Walker : MonoBehaviour
{
    public Transform leftTarget;
    public Transform rightTarget;

    public float speed = 5;
    public float stopTime = 1;

    public Direction currentDirrection;

    public UnityEvent eventOnLeftTarget;
    public UnityEvent eventOnRightTarget;

    public Transform rayStart;

    private bool isStopped;

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;
    }

    void Update()
    {
        if (isStopped == true)
        {
            return;
        }

        if (currentDirrection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * speed, 0, 0);
            if (transform.position.x < leftTarget.position.x)
            {
                currentDirrection = Direction.Right;
                isStopped = true;
                Invoke("continueWalk", stopTime);
                eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            if (transform.position.x > rightTarget.position.x)
            {
                currentDirrection = Direction.Left;
                isStopped = true;
                Invoke("continueWalk", stopTime);
                eventOnRightTarget.Invoke();
            }
        }

        //RaycastHit hit;
        //if (Physics.Raycast(rayStart.position, Vector3.down, out hit))
        // {
        //   transform.position = hit.point;
        //}
    }

    private void continueWalk()
    {
        isStopped = false;
    }
}
