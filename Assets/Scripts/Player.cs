using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        h = h * moveSpeed * Time.deltaTime;
        v = v * moveSpeed * Time.deltaTime;
        Vector3 vector = new Vector3(h,0,v);
        this.transform.position += vector;
        transform.forward = vector;
    }
}
