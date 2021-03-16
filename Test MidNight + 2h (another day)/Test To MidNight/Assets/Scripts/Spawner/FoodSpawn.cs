using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject food;

    private void Start()
    {
        Instantiate(food, this.transform.position, Quaternion.identity);
    }
}
