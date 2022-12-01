using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int money, health;
    private string item;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EatItem(int mValue, int hValue)
    {
        if (item == "Money")
        {
            money += mValue;
        }
        else if (item == "Healthp")
        {
            health += hValue;
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) 
    {
         if (collision.collider.tag == "Player")
         {
            EatItem(100, 25);
         }
    }
}
