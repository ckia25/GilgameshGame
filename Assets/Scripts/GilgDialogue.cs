//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GilgDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject enkidu;
    public GameObject gilgamesh;
    public Text text;
    public string[] texts;
    public int index;
    public bool dActive;


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        dActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dActive)
        {
            if (Input.GetKeyUp(KeyCode.Space) && index < texts.Length)
            {
                index += 1;
                if (index == texts.Length)
                {
                    Debug.Log("NEXT SCENE");
                    SceneManager.LoadScene(1);
                } else
                {
                    text.text = texts[index];
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dActive = true;
            dialogueBox.SetActive(true);
            text.text = texts[index];
        }
    }
}
