//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            transform.position = player.position + offset;
        }
        
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
