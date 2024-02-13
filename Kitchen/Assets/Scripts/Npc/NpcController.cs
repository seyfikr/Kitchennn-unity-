using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NpcController : MonoBehaviour
{
    NpcManager npcManager;
    [SerializeField] float moveSpeed = 4f;
    private List<Transform> removedPoints = new List<Transform>();
    private void Awake()
    {
        GameObject gameManager = GameObject.Find("NPCmanager");
        npcManager = gameManager.GetComponent<NpcManager>();
    }
    void Start()
    {
        MoveToRandomPoint();
    }
    void MoveToRandomPoint()
    {
        int randomIndex = Random.Range(0, npcManager.movePoint.Count);
        Transform targetPoint = npcManager.movePoint[randomIndex];
        removedPoints.Add(npcManager.movePoint[randomIndex]);
        npcManager.movePoint.RemoveAt(randomIndex);

        StartCoroutine(MoveEnemy(targetPoint.position));
        //StartCoroutine(RestoreRemovedPoints());
    }
    IEnumerator MoveEnemy(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.LookAt(targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }     
    }
    IEnumerator RestoreRemovedPoints()
    {

        yield return new WaitForSeconds(15f);
        npcManager.movePoint.AddRange(removedPoints);
        removedPoints.Clear();
    }
}
