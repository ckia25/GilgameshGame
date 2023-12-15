//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CollectionGame : MonoBehaviour
{
    public GameObject beer;
    public GameObject bread;
    public GameObject barber;
    public GameObject clothing;
    public GameObject enkidu;
    public GameObject flag;
    public GameObject shamhat;
    public int numItemsCollected;
    public int numItems;
    public bool beerCollected = false, breadCollected = false, barberCollected = false, clothCollected = false;
    public Sprite shaved, hairyClothing, shavedClothing;
    public GameObject wedDude;
    public GameObject barrier;


    // Start is called before the first frame update
    void Start()
    {
        numItems = 4;
        numItemsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numItemsCollected == 4)
        {
            shamhat.SetActive(false);
            Destroy(flag);
            wedDude.SetActive(true);
            //beer.SetActive(false);
            //bread.SetActive(false);
            //clothing.SetActive(false);
            //barber.SetActive(false);
            barrier.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Beer")
        {
            beer.SetActive(true);
            if (!beerCollected)
            {
                numItemsCollected += 1;
            }
            beerCollected = true;  

        } else if (other.gameObject.tag == "Bread")
        {
            bread.SetActive(true);
            if (!breadCollected)
            {
                numItemsCollected += 1;
            }

            breadCollected = true;

        } else if (other.gameObject.tag == "Barber")
        {
            barber.SetActive(true);
            if (!barberCollected)
            {
                numItemsCollected += 1;
                if (clothCollected)
                {
                    enkidu.GetComponent<SpriteRenderer>().sprite = shavedClothing;
                } else
                {
                    enkidu.GetComponent<SpriteRenderer>().sprite = shaved;
                }
            }
            barberCollected = true;
        } else if (other.gameObject.tag == "Clothing")
        {
            clothing.SetActive(true);
            if (!clothCollected)
            {
                numItemsCollected += 1;
                if (barberCollected)
                {
                    enkidu.GetComponent<SpriteRenderer>().sprite = shavedClothing;
                }
                else
                {
                    enkidu.GetComponent<SpriteRenderer>().sprite = hairyClothing;
                }

            }
            clothCollected = true;
        }
    }
}
