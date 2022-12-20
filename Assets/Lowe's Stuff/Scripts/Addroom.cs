using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addroom : MonoBehaviour
{
    private RoomTemplates Roomlist; 
    // Start is called before the first frame update
    void Start()
    {
        Roomlist = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>(); //Den letar ett objekt med tagen Room och sedan tar den scriptet Roomtemplates
        Roomlist.rooms.Add(gameObject); //Den lägger till gameobjecten detta script sitter på i rooms listan som ligger i Roomtemplates         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
