//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject dialogueBox;
    public Text text;
    public int index;
    public float cooldown = 1f;
    public float prevTime;
    public string[] texts;
        // Start is called before the first frame update
    void Start()
    {
        index = 0;
        dialogueBox.SetActive(true);
        text.text = texts[index];
        prevTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            prevTime = Time.time;
            index += 1;
        }
        //if (Input.GetKeyUp(KeyCode.LeftArrow) && Time.time - prevTime > cooldown)
        //{
        //    prevTime = Time.time;
        //    index = (int)Mathf.Max(0, index - 1);
        //}
        if (index >= texts.Length)
        {
            text.text = "";
            gameController.SetActive(true);
            dialogueBox.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            text.text = texts[index];
        }
        

    }
}
