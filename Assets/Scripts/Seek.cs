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
    private Rigidbody2D rb;
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
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
        Vector3 targetPos = (target.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + targetPos * speed * Time.deltaTime);
    }
}
