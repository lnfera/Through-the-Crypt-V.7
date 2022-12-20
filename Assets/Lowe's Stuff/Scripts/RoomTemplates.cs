using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    //I det h�r scriptet s� finns alla listor som RoomSpawner och DecorationSpawner beh�ver
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
        if (WaitTime <= 0 && BossSpawned == false) //Ifall Waittime �r mindre �n noll och ifall det sista rummer har inte spawnat
        {
            for (int i = 0; i <= rooms.Count; i++) // S� r�knar den hur m�nga rum som finns i listan 
            {

                if (i == rooms.Count - 1)
                {
                    Transform Child = rooms[i].transform.GetChild(0); //Den tar golv childen av rummet som �r sist i listan
                    Child.gameObject.SetActive(false); //Den deaktiverar golvet s� det inte blir n�gon clipping mellan den och h�let
                    Instantiate(Boss, rooms[i].transform.position, Quaternion.identity); //Den spawnar h�let i marken
                    BossSpawned = true; //den s�tter BossSpawned till True s� inga fler kan spawna
                    Debug.Log(BossSpawned); // Den skriver ut vilken ifall BossSpawned �r true eller false
                }

            }
        }
        else
        {
            WaitTime -= Time.deltaTime; //R�knar ner ifr�n v�ran waitTime (Detta �r ett annat s�tt att f� den att v�nta utan att anv�nda en coroutine)
        }
    }
}