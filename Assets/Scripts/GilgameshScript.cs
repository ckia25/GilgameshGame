//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GilgameshScript : MonoBehaviour
{

    public int health;
    public bool defeated;
    public GameObject dialogueBox;
    public Text text;
    public string[] texts;
    public int index;
    public Text healthText;

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "Gilgamesh Life: " + health;


        if (defeated)
        {
            if (Input.GetKeyUp(KeyCode.Space) && index < texts.Length)
            {
                index += 1;
                if (index == texts.Length)
                {
                    Debug.Log("Game Over");
                    SceneManager.LoadScene(2);


                }
                else
                {
                    text.text = texts[index];
                }
            }
        }
        
    }


    public void dealDamage(int d)
    {
        if (!defeated)
        {
            health -= d;
            Debug.Log(health);
        }
        if (health <= 0) {
            defeated = true;
            Debug.Log("Defeated");
            dialogueBox.SetActive(true);

        }
        
    }
}
