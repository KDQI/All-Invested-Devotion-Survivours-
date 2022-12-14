using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private int dmg, particleId;
    [SerializeField]
    private bool pierceEnemies;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 3f);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<Enemy>().TakeDamage(dmg);
            if(!pierceEnemies)
            {
                Destroy(gameObject);
            }
        }
       
    }

    public void OnDestroy()
    {
        ObjectSpawner.instance.SpawnParticle(particleId, this.transform.position);
    }
}
