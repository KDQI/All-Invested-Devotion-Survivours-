using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    [SerializeField]
    private string targetName;
    [SerializeField]
    private bool seeking = true;
    [SerializeField]
    private float defaultSpeed;
    private float speed;
    private GameObject target;
    void Start()
    {
        target = GameObject.Find(targetName);
    }

    public GameObject getTarget()
    {
        speed = defaultSpeed;
        return target;
    }


    void FixedUpdate()
    {
        if(seeking)
        {
            MoveTowardsTarget();
        }
    }

    public void startSeeking()
    {
        seeking = true;
    }

    public void stopSeeking()
    {
        seeking = false;
    }

    public void setSpeed(float f)
    {
        speed = f;
    }

    public void resetSpeed()
    {
        speed = defaultSpeed;
    }

    public bool isSeeking()
    {
        if(seeking)
        {
            return true;
        }else
        {
            return false;
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 targetPos = target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
    }
}
