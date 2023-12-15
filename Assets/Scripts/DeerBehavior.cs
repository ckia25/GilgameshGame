//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class DeerBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 direction;
    public float ms;
    private float interval;
    private float refTime;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        interval = 1f;
        refTime = Time.time;
        direction.x = (Random.Range(-1, 2));
        direction.y = (Random.Range(-1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > refTime + interval)
        { 
            refTime = Time.time;
            direction.x = (Random.Range(-1, 2));
            direction.y = (Random.Range(-1, 2));
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * ms * Time.fixedDeltaTime);   
    }

    public void dealDamage(int d)
    {
        health -= d;
        if (health <=0) {
            Destroy(gameObject);
        }
    }

}
