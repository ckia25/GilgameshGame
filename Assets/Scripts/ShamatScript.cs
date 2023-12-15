//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShamatScript : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Rigidbody2D rb;
    public string[] texts;
    public string[] herdText;
    public int herdIndex;
    public bool dActive = false;
    public int index = 0;
    public Transform targetLocation;
    private bool readyToMove;
    public float ms;
    private bool atTarget = false;
    public Sprite sp1, sp2;
    public GameObject enkidu;
    private bool d2Active;
    // Start is called before the first frame update
    void Start()
    {

        readyToMove = false;
        herdIndex = 0;
        d2Active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dActive)
        {
            if (Input.GetKeyUp(KeyCode.Space) && !readyToMove)
            {
                index += 1;
                if (index == texts.Length - 1)
                {
                    enkidu.GetComponent<SpriteRenderer>().sprite = sp1;
                }
                if (index >= texts.Length)
                {
                    dActive = false;
                    dialogueBox.SetActive(false);
                    readyToMove = true;
                }
                else
                {
                    dialogueText.text = texts[index];
                }
                
            }
            
        } else if (d2Active)
        {
            if (Input.GetKeyUp(KeyCode.Space) && herdIndex < herdText.Length)
            {
                herdIndex += 1;
                if (herdIndex >= herdText.Length)
                {
                    d2Active = false;
                    dialogueBox.SetActive(false);
                    //readyToMove = true;
                }
                else
                {
                    dialogueText.text = herdText[herdIndex];
                }

            }
        }
    }


    private void FixedUpdate()
    {
        if (readyToMove && !atTarget)
        {
            Vector3 temp = targetLocation.position - transform.position;
            if (temp.sqrMagnitude < 0.01)
            {
                atTarget = true;
            }
            rb.MovePosition(rb.position + new Vector2(temp.x, temp.y).normalized * ms * Time.fixedDeltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && index < texts.Length)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = texts[index];
            dActive = true;
            
        }


        if (collision.gameObject.tag == "Player" && atTarget)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = herdText[herdIndex];
            d2Active = true;

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && atTarget)
        {
            dialogueBox.SetActive(false);
            herdIndex = 0;
            d2Active = false;
        }
    }
}
