using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    public GameObject[] Npc;
    [SerializeField] Transform spawmPoint;
    public List<Transform> movePoint = new List<Transform>();
    void Start()
    {
        //SpawnRandomNpc();
        InvokeRepeating("SpawnRandomNpc", 0f, 5f);
    }

    void SpawnRandomNpc()
    {
        int randomIndex = Random.Range(0, Npc.Length);
        GameObject spawnedNpc = Instantiate(Npc[randomIndex], spawmPoint.position, Quaternion.identity);
        spawnedNpc.transform.SetParent(spawmPoint);
    }
}
