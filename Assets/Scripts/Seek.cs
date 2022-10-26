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
        speed = defaultSpeed;
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.Find(targetName);
    }

    public GameObject GetTarget()
    {
        return target;
    }


    void FixedUpdate()
    {
        
        if(seeking)
        {
            MoveTowardsTarget();
        }
    }

    public void StartSeeking()
    {
        seeking = true;
    }

    public void StopSeeking()
    {
        seeking = false;
    }

    public void SetSpeed(float f)
    {
        speed = f;
    }

    public void SlowSpeed(float f)
    {
        Debug.Log("Slowing speed");
        speed -= f;
    }

    public float GetDefaultSpeed()
    {
        return defaultSpeed;
    }

    public void ResetSpeed()
    {
        speed = defaultSpeed;
    }

    public bool IsSeeking()
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
        Vector3 targetPos = (target.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + targetPos * speed * Time.deltaTime);
    }
}
