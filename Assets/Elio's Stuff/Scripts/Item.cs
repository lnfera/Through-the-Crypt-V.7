using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string item;
    // Start is called before the first frame update
    void Start()
    {
        item = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EatItem(int value)
    {
        
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision) 
    {
         if (collision.collider.tag == "Player")
         {

         }
    }
}
