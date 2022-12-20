using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    private static int RandFurniture;
    public int SpawnChans;
    private RoomTemplates templates;
    // Start is called before the first frame update

    void Start()
    {
        templates = FindObjectOfType<RoomTemplates>(); //den hittar Objektet Roomtemplates i scenen
        int Rand1 = Random.Range(0, SpawnChans); //Den rullar en siffra mellan 1 och spawnchansen, T.ex mellan 1 och 2 d� �r det en 50% chans att en m�bel spawnar
        Debug.Log(Rand1); //Sedan s� skriver den ut den siffran som den rullade
        if (Rand1 >= 1) //Om siffran �r st�rre �n 1 s� kommer den ta en m�bel ifr�n furniture listen som finns i Roomtemplates. Den kommer sedan spawna m�beln p� sig sj�lv
        {
            int Rand2 = Random.Range(0, templates.furniture.Length);
            Instantiate(templates.furniture[Rand2], transform.position, templates.furniture[Rand2].transform.rotation);
            Debug.Log("Spawned");
        }
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
