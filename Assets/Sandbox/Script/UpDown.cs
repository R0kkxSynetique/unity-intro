using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    float counter = 0;
    float speed = 1;
    public float width = 1;
    public float height = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime*speed;
        float z = transform.position.z + Mathf.Cos(counter)*width;
        float y = transform.position.y + Mathf.Sin(counter)*height;
        float x = transform.position.x;

        transform.position = new Vector3(x,y,z);
    }
}
