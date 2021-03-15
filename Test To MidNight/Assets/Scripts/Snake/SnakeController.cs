using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0, 3)]
    public float bonesDistance;
    [Range(0, 4)]
    public float speed;
    public GameObject bonePrefab;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * speed);

        float angel = Input.GetAxis("Horizontal") * 2;
        _transform.Rotate(0, angel, 0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = bonesDistance * bonesDistance;
        Vector3 previousPosition = _transform.position;
        var previousRotation = _transform.rotation;

        foreach(var bone in Tails)
        {
            if((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = bone.position;
                var rot = bone.rotation;
                bone.position = previousPosition;
                previousPosition = temp;
                bone.rotation = previousRotation;
                previousRotation = rot;
            }
            else
            {
                break;
            }
        }

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);

            var bone = Instantiate(bonePrefab);
            Tails.Add(bone.transform);
        }

        if(other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
