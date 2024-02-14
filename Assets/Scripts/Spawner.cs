using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zoroCube;
    public GameObject empty;
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    void Update()
    {
        
    }

    private void SpawnZoroCube()
    {
        Instantiate(zoroCube,empty.transform.position,Quaternion.identity);
    }
    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            SpawnZoroCube();
        }
    }
}
