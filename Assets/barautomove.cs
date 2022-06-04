using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barautomove : MonoBehaviour
{

    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Vector2.left);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "up") GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
        else if (col.gameObject.name == "down") GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }
}
