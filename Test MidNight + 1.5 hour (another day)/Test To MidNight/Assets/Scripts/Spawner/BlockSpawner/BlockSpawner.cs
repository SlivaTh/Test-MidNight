using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block;

    private float waitTime = 3f;

    private bool spawned = false;

    private void Start()
    {
        Invoke("DeleteSpawner", 5f);
        spawned = false;
    }

    private void Update()
    {
        waitTime = waitTime - Time.deltaTime;
        
        if(waitTime <= 0 && !spawned)
        {
            spawned = true;
            Instantiate(block, this.transform.position, Quaternion.identity);
        }
    }

    private void DeleteSpawner()
    {
        Destroy(gameObject);
    }
}
