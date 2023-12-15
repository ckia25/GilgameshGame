//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnkiduBattle : MonoBehaviour
{
    public bool defeated;
    public int health;

    public float ms;
    public Rigidbody2D rb;
    public Vector2 direction = new Vector2(0f, 0f);
    private float x;
    private float y;
    private float mag;
    public GameObject dialogueBox;
    public Text text;
    public GameObject[] hearts;
    private int heartIndex;
    public float timeBTWattack;
    public float timestart;

    public GameObject up;
    public GameObject mid;
    public GameObject down;
    public GameObject enkidu;

    public Sprite spUp;
    public Sprite spMid;
    public Sprite spDown;
    public Sprite sp;

    public float animationDuration;
    public float animationStart;
    public bool animate = false;
    public Transform spawnPoint;

    public GameObject punch;



    private void Start()
    {
        heartIndex = hearts.Length - 1;
    }

    void Update()
    {
        attack();
        if (animate && Time.time - animationStart > animationDuration)
        {
            enkidu.GetComponent<SpriteRenderer>().sprite = sp;
            animate = false;
            up.SetActive(false);
            mid.SetActive(false);
            down.SetActive(false);
        }
        x = Input.GetAxisRaw("Horizontal");

        if (x > 0 && transform.rotation.y == 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), 180);
        }
        else if (x < 0 && transform.rotation.y == 1)
        {
            transform.Rotate(new Vector3(0, 1, 0), 180);
        }
        y = Input.GetAxisRaw("Vertical");
        mag = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        if (mag == 0)
        {
            mag = 1;
        }
        direction.x = x / mag;
        direction.y = y / mag;

    }

    void FixedUpdate()
    {
        

        rb.MovePosition(rb.position + direction * ms * Time.fixedDeltaTime);
        //attack();
    }

    public void dealDamage(int d)
    {
        if (!defeated)
        {
            health -= d;
        }
        if (health <= 0)
        {
            defeated = true;
            Debug.Log("Defeated");
        }

    }

    private void attack()
    {
        
        if (Input.GetKeyUp(KeyCode.Space) && Time.time - timestart > timeBTWattack)
        {
            
            timestart = Time.time;

            sendBullet();
            if (y == 0)
            {
                //mid.SetActive(true);
                enkidu.GetComponent<SpriteRenderer>().sprite = spMid;

            } else if (y == 1)
            {
                //up.SetActive(true);
                enkidu.GetComponent<SpriteRenderer>().sprite = spUp;
            }
            else
            {
                //down.SetActive(true);
                enkidu.GetComponent<SpriteRenderer>().sprite = spDown;
            }
            animationStart = Time.time;
            animate = true;
            


        }
    }

    private void sendBullet()
    {
        if (transform.rotation.y == 0)
        {
            spawnPoint.right = (new Vector2(1, -1*y)).normalized;
        } else
        {
            spawnPoint.right = (new Vector2(-1, -1*y)).normalized;
        }
        
        Instantiate(punch, spawnPoint.position, spawnPoint.rotation);
        timestart = Time.time;

    }


}
