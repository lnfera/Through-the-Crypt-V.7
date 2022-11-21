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
        templates = FindObjectOfType<RoomTemplates>();
        int Rand1 = Random.Range(0, SpawnChans);
        Debug.Log(Rand1);
        if (Rand1 == 1)
        {
            int Rand2 = Random.Range(0, templates.furniture.Length);
            Instantiate(templates.furniture[Rand2], transform.position, templates.furniture[Rand2].transform.rotation);
            Debug.Log("Spawned");
        }
    }
    private void Awake()
    {

    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
