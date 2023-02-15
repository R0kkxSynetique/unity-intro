using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle_around : MonoBehaviour
{
    public GameObject target;
    public float distance = 5f;

    private float xSpeed = 10f;

    private float x = 0f;
    private float y = 0f;

    void Start()
    {
        var angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void Update()
    {
        if (target)
        {
            x += xSpeed * Time.deltaTime;

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0, 0, -distance) + target.transform.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
