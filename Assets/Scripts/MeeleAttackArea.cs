//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackArea : MonoBehaviour
{
    public string enemyTag;
    public int damage;
    public float coolDown;
    public float start;
    public bool attack;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    attack = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Time.time - start > coolDown)
    //    {
    //        attack = true;
    //    }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (!attack)
    //    {
    //        return;
    //    }
    //    if (collision.gameObject.tag == enemyTag)
    //    {
    //        if (collision.gameObject.TryGetComponent<GilgameshScript>(out GilgameshScript gilg))
    //        {
    //            gilg.dealDamage(damage);
    //        }
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == enemyTag)
        {
            if (collision.gameObject.TryGetComponent<GilgameshScript>(out GilgameshScript gilg))
            {
                gilg.dealDamage(damage);
                gameObject.SetActive(false);
               
            }
        }
        
    }
}
