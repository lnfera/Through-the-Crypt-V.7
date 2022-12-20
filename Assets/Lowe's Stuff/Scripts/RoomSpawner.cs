using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RoomSpawner : MonoBehaviour
{
    public int openingdirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    private RoomTemplates templates;
    private int rand;
    public bool SpawnerInWay = false;
    public bool RoomInWay = false;
    public float waitTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = FindObjectOfType<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
        Debug.Log("Spawned");
    }


    void Spawn()
    {
        if (SpawnerInWay == false && RoomInWay == false) //Ifall det finns en Spawner eller ett rum iv�gen 
        {
            if (openingdirection == 1) //Ifall openingdir �r 1 s� ska ett rum fr�n bottomRooms listan spawna vid spawnpointen
            {
                var rand = Random.Range(0, templates.bottomRooms.Length);
                Debug.Log("Chosen Room");
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingdirection == 2) //Om rummet inte har openingdir 1 och har ist�llet openingdir 2, tar den ett rum fr�n toproom ist�llet
            {
                var rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingdirection == 3) //Om rummet inte har openingdir 2 och har ist�llet openingdir 3, tar den ett rum fr�n leftroom ist�llet
            {
                var rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingdirection == 4) //Om rummet inte har openingdir 3 och har ist�llet openingdir 4, tar den ett rum fr�n rightroom ist�llet
            {
                var rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Room") //Ifall Spawnern tr�ffar ett rum s� f�rst�rs gameobjekten s� inga fler rum kan spawnas p� den punkten
        {
            RoomInWay = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("SpawnPoint")) //Ifall spawnern tr�ffar en annan spawner s� startas coroutinen EndSpawn
        {
            SpawnerInWay = true;
            StartCoroutine(EndSpawn());
        } 
    
    }

    IEnumerator EndSpawn() //N�r tv� spawners colliderar s� v�ntar den 0.1 sekund s� dom inte tar bort varandra p� direkten, 
                           //Den st�nger sedan av collidern s� scriptet inte repeteras efterdet s� spawnar den en EndRoom och till sist s� f�rst�rs spawnern 
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(templates.EndRooms[0], transform.position, templates.EndRooms[0].transform.rotation);
        Destroy(gameObject);
    }
}
