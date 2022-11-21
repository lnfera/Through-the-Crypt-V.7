using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;
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
    // Start is called before the first frame update
    void Start()
    {
        templates = FindObjectOfType<RoomTemplates>();
        Invoke(nameof(Spawn), 0.1f);
        Debug.Log("Spawned");
    }


    void Spawn()
    {
        if (SpawnerInWay == false && RoomInWay == false)
        {
            if (openingdirection == 1)
            {
                var rand = Random.Range(0, templates.bottomRooms.Length);
                Debug.Log("Chosen Room");
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingdirection == 2)
            {
                var rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingdirection == 3)
            {
                var rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingdirection == 4)
            {
                var rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            NavMeshBuilder.BuildNavMesh();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Room")
        {
            RoomInWay = true;
            Destroy(gameObject);
        }

        if (other.CompareTag("SpawnPoint"))
        {
            SpawnerInWay = true;
            StartCoroutine(EndSpawn());
        } 
    
    }

    IEnumerator EndSpawn()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<Collider>().enabled = false;
        Instantiate(templates.EndRooms[0], transform.position, templates.EndRooms[0].transform.rotation); //händer samma frame som RoomInWay
        Destroy(gameObject);
    }
}
