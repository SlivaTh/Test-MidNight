using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    [SerializeField]
    private Color cl = new Color(0f, 0f, 0f, 0f);

    private void Update()
    {
        gameObject.GetComponent<MeshRenderer>().sharedMaterial.color = cl;
    }
}
