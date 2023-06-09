using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{
    bool isCollected = false;

    void ShowCoin()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
        isCollected = false;

    }
    void HideCoin()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
    void CollectCoin()
    {
        isCollected = true;
        HideCoin();
        GameManager.sharedInstance.CollectCoin();

    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Player")
        {
            CollectCoin();

        }    
    }
}
