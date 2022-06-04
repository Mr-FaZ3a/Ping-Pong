using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baller : MonoBehaviour
{
    public Text scorep1;
    public Text scorep2;
    int rightscore = 0;
    int leftscore = 0;
    public int speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
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
  
  
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "player1") 
        {
            // Debug.Log("ball pos: " + transform.position);
            // Debug.Log("racket pos: " + col.transform.position);
            // Debug.Log("hight: " + col.collider.bounds.size.y);
            // Calculate hit Factor
            
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

            // Hit the right Racket?
        else if (col.gameObject.name == "player2")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "right")
        {
            leftscore++;
            scorep1.text = leftscore.ToString();
        }
        else if ( col.gameObject.name == "left")
        {
            rightscore++;
            scorep2.text = rightscore.ToString();
        }



    }
    float hitFactor(Vector2 ballpos, Vector2 playerpos, float playerheight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballpos.y - playerpos.y) / playerheight;
    }
}
