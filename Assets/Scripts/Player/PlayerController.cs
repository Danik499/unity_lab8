using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Vector3 posToMove;
    private bool posSelected = false;
    private NavMeshAgent agent;
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            posSelected = Physics.Raycast(ray, out hit, 1000);
            if (posSelected)
            {
                posToMove = hit.point;
            }
        }
        if (posSelected)
        {
            agent.SetDestination(posToMove);
        }
    }
}
