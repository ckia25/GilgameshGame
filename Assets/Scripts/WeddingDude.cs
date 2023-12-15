//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeddingDude : MonoBehaviour
{

    public string[] texts;
    public GameObject dialogueBox;
    public Text dialogueText;
    private int index;
    private bool dActive;
    public GameObject exclaim;
    
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dActive && Input.GetKeyUp(KeyCode.Space))
        {
            index += 1;
            exclaim.SetActive(false);
            
            if (index >= texts.Length)
            {
                dActive = false;
                dialogueBox.SetActive(false);

            }
            else
            {
                dialogueText.text = texts[index];
            }
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


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueBox.SetActive(false);
            index = 0;
            dActive = false;
        }

    }


}
