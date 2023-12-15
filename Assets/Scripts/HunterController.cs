//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    public GameObject target = null;
    public Vector2 direction = new Vector2(0, 0);
    public float ms;
    public bool inRangeDeer = false;
    public Rigidbody2D rb;
    public Transform arrowSpawnPoint;
    public GameObject arrow;
    private float refTime;
    public float fireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTarget(GameObject t)
    {
        target = t;
        refTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || inRangeDeer) 
        {
            direction.x = 0;
            direction.y = 0;
        }
        else
        {
            Vector3 temp = target.transform.position - transform.position;
            float mag = Mathf.Sqrt(Mathf.Pow(temp.x, 2) + Mathf.Pow(temp.y, 2));
            if (mag == 0)
            {
                mag = 1;
            }
            direction.x = temp.x / mag;
            direction.y = temp.y / mag;
            if (transform.rotation.y == 0 && temp.x > 0)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
                
            } else if (transform.rotation.y == 180 && temp.x < 0)
            {
                transform.Rotate(new Vector3(0, 1, 0), 180);
            }
         
        }

        if (Time.time - refTime > fireRate)
        {
            arrowSpawnPoint.right = -1 * direction;
            Instantiate(arrow, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            refTime = Time.time;
        }
                
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * ms * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
