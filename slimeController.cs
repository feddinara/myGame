using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slimeController : MonoBehaviour
{
    Transform tr;
    NavMeshAgent agent;
    public GameObject player; 
    Transform playerTR;
    float x;
    float z;
    GameObject clone;
    NavMeshAgent cloneNMA;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); 
        agent = GetComponent<NavMeshAgent>();
        playerTR = player.GetComponent<Transform>();
        cloneNMA = clone.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTR.position);
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
