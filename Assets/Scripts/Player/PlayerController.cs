using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    private NavMeshAgent agent;

    public static Vector3 pos;
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        pos = transform.position;
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask platformLayer = LayerMask.GetMask("Platform");
            LayerMask enemyLayer = LayerMask.GetMask("Enemy");
            if (Physics.Raycast(ray, out hit, 1000, platformLayer) && Physics.Raycast(ray, out hit, 1000, enemyLayer))
            {
                GameObject fireball = Instantiate(bullet);
                fireball.transform.position = transform.position + hit.point.normalized;
                fireball.transform.LookAt(hit.point);
            }
            else if (Physics.Raycast(ray, out hit, 1000, platformLayer))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
