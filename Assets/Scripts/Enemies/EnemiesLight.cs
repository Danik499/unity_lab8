using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLight : MonoBehaviour
{
    private GameObject child;
    private int layer;
    void Start()
    {
        layer = 0;
        child = transform.Find("Point Light").gameObject;
        child.GetComponent<Light>().enabled = false;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool check = Physics.Raycast(ray, out hit, 1000);
        if (check)
        {
            layer = hit.transform.gameObject.layer;
            if (layer == 9)
            {
                child = hit.transform.Find("Point Light").gameObject;
                child.GetComponent<Light>().enabled = true;
            }
            else
            {
                child.GetComponent<Light>().enabled = false;
            }
        }
    }
}
