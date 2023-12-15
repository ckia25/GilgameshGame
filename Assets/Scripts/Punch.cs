//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public int damage = 1;
    private Vector2 direction;
    public float ms;
    private Rigidbody2D rb;
    private float startTime;
    public float duration;
    public string sourceTag;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -1 * transform.right * ms;
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (Time.time - startTime > duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.TryGetComponent<GilgameshScript>(out GilgameshScript gilg))
        {
            gilg.dealDamage(damage);
        }
        if (collision.gameObject.tag != sourceTag)
        {
            Destroy(gameObject);
        }
        


    }
}
