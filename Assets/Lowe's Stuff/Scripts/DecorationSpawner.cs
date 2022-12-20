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
        int Rand1 = Random.Range(0, SpawnChans); //Den rullar en siffra mellan 1 och spawnchansen, T.ex mellan 1 och 2 då är det en 50% chans att en möbel spawnar
        Debug.Log(Rand1); //Sedan så skriver den ut den siffran som den rullade
        if (Rand1 >= 1) //Om siffran är större än 1 så kommer den ta en möbel ifrån furniture listen som finns i Roomtemplates. Den kommer sedan spawna möbeln på sig själv
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
