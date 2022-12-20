using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    //I det här scriptet så finns alla listor som RoomSpawner och DecorationSpawner behöver
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] EndRooms;
    public GameObject[] furniture;
    public List<GameObject> rooms = new List<GameObject>();

    public float WaitTime;
    private bool BossSpawned = false;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime <= 0 && BossSpawned == false) //Ifall Waittime är mindre än noll och ifall det sista rummer har inte spawnat
        {
            for (int i = 0; i <= rooms.Count; i++) // Så räknar den hur många rum som finns i listan 
            {

                if (i == rooms.Count - 1)
                {
                    Transform Child = rooms[i].transform.GetChild(0); //Den tar golv childen av rummet som är sist i listan
                    Child.gameObject.SetActive(false); //Den deaktiverar golvet så det inte blir någon clipping mellan den och hålet
                    Instantiate(Boss, rooms[i].transform.position, Quaternion.identity); //Den spawnar hålet i marken
                    BossSpawned = true; //den sätter BossSpawned till True så inga fler kan spawna
                    Debug.Log(BossSpawned); // Den skriver ut vilken ifall BossSpawned är true eller false
                }

            }
        }
        else
        {
            WaitTime -= Time.deltaTime; //Räknar ner ifrån våran waitTime (Detta är ett annat sätt att få den att vänta utan att använda en coroutine)
        }
    }
}