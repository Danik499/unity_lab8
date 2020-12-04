using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    public int secondsLeft = 5;
    private int secondsCount;
    public GameObject Enemy;
    void Start()
    {
        secondsCount = secondsLeft;
        StartCoroutine("Tick");
    }

    void Update()
    {
        if (secondsLeft == 0)
        {
            secondsLeft = secondsCount;
            int x = Random.Range(-10, 10);
            int z = Random.Range(-10, 10);
            Instantiate(Enemy, new Vector3(x, 1, z), Quaternion.identity);
        }   
    }

    IEnumerator Tick()
    {
        while (secondsLeft >= 0)
        {
            yield return new WaitForSeconds(1);
            secondsLeft--;
        }
    }
}
