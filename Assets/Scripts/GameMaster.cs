//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public GameObject deer;
    public GameObject hunter;
    public GameObject enkidu;
    public int hunterCount = 0;
    public int deadDeerCount = 0;
    private bool isDeerAlive;
    private bool isHunterAlive;
    public float[] xVals = {-2.7f, -2.0f, -1.1f, 0f, 1.1f, 2.0f, 2.7f, 2.1f, 1.6f};
    public float[] yVals = { 3.0f, -0.5f, 3.0f, -0.5f, 3.0f, -0.5f, 3.0f, -0.5f, 3.0f};
    private int randIndex;
    private GameObject targetDeer;
    private GameObject currentHunter;
    
    public GameObject dialogueBox;
    public Text text;
    public int textNum;
    public string[] dialogues = { "The Hunter has fled!", "There is someone waiting for you..."};
    public GameObject canvas;
    
    public GameObject shamat;
    public GameObject[] deerLives;
    public int deerIndex;

    public GameObject barrier;
    

    // Start is called before the first frame update
    void Start()
    {
        deerIndex = deerLives.Length - 1;
        textNum = 0;
        
        randIndex = Random.Range(0, xVals.Length);
        currentHunter = Instantiate(hunter, new Vector3(xVals[randIndex], yVals[randIndex], 0), Quaternion.identity);
        isHunterAlive = true;
        hunterCount = 1;
        newDeer();
        dialogueBox.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (enkidu == null)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {

            if (currentHunter == null)
            {
                isHunterAlive = false;
            }
            if (targetDeer == null)
            {
                isDeerAlive = false;
                deerLives[deerIndex].SetActive(false);
                deerIndex -= 1;
            }
            if (deerIndex == -1)
            {
                dialogueBox.SetActive(true);
                text.text = "Game Over! Click space to restart";
                Destroy(enkidu);
            }
            if (!isDeerAlive)
            {
                deadDeerCount += 1;
                newDeer();
            }

            if (!isHunterAlive && hunterCount < 3)
            {
                newHunter();
            }
            else if (!isHunterAlive && hunterCount >= 3 && textNum >= 0)
            {
                dialogueBox.SetActive(true);
                
                text.text = dialogues[textNum];
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    textNum += 1;
                    if (textNum >= dialogues.Length)
                    {
                        dialogueBox.SetActive(false);
                        shamat.SetActive(true);
                        textNum = -1;
                        deactivateAll();
                        barrier.SetActive(false);

                    }
                }

            }
           
        }
    }

    public void newDeer()
    {
        int index = Random.Range(0, xVals.Length);
        targetDeer = Instantiate(deer, new Vector3(xVals[index], yVals[index], 0), Quaternion.identity);
        isDeerAlive = true;
        if (currentHunter != null && currentHunter.TryGetComponent<HunterController>(out HunterController huntComp))
        {
            huntComp.setTarget(targetDeer);
        }
    }

    public void newHunter()
    {
        randIndex = Random.Range(0, xVals.Length);
        currentHunter = Instantiate(hunter, new Vector3(xVals[randIndex], yVals[randIndex], 0), Quaternion.identity);
        hunterCount += 1;
        isHunterAlive = true;
        if (currentHunter.TryGetComponent<HunterController>(out HunterController huntComp))
        {
            huntComp.setTarget(targetDeer);
        }
    }

    private void deactivateAll()
    {
        for (int i = 0; i < deerLives.Length; i++)
        {
            deerLives[i].SetActive(false);
        }
    }

}
