using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public int speed = 5;
    public string axis;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void FixedUpdate()
    {
        float v = Input.GetAxisRaw(axis) * speed;
        Debug.Log(v);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,v);
    }
}
