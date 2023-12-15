//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public int damage = 1;
    private Vector2 direction;
    public float ms;
    private Rigidbody2D rb;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -1*transform.right * ms;
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.TryGetComponent<DeerBehavior>(out DeerBehavior deer))
       {
            deer.dealDamage(damage);
       }
       else if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement pm))
       {
            pm.dealDamage(damage);
       }


        if (collision.gameObject.tag != "Hunter" && collision.gameObject.tag != "Water")
        {
            Destroy(gameObject);

        }
     
       
    }
}
