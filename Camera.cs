using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform lookAt;
    private Vector3 start;
    private Vector3 move;
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        start = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = lookAt.position + start;

        move.x = 0;

        move.y = Mathf.Clamp(move.y, 1, 10);

        transform.position = move;
    }
}
