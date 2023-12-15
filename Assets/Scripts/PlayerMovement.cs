//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
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


    private void Start()
    {
        heartIndex = hearts.Length-1;
    }
    // Update is called once per frame
    void Update()
    {
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
    }

    public void dealDamage(int d)
    {

        hearts[heartIndex].SetActive(false);
        heartIndex -= 1;

        if (heartIndex == -1)
        {
            dialogueBox.SetActive(true);
            text.text = "Game Over! Click space to restart";
            Destroy(gameObject);
        }

    }
}
