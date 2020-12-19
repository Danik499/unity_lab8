using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * 15f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 9)
        {
            Destroy(collider.gameObject);
            Destroy(this.transform.Find("Particle System").gameObject);
            Destroy(this.gameObject);
        }
    }
}
