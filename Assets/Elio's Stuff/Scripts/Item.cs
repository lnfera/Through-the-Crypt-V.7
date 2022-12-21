using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private string item;
    public int potion;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EatItem(Player player)
    {
        //Adds money or health depending on what the item is... money was however never implemented
        if (item == "Money")
        {
            //player.money += mValue;
        }
        else if (item == "Healthp")
        {
            player.health += potion;
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) 
    {
        //
        if (collision.collider.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            EatItem(player);
        }
    }
}
