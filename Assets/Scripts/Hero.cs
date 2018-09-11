using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hero : MonoBehaviour {
    public int Hp { get; set; }
    public float maxSpeed { get; set; }
    public float jumpForce { get; set; }
    public int sumJumps { get; set; }

    bool grounded = false;
    Rigidbody2D rigidbodyHero;
    int numberJump;
    float move;

    void Start()
    {
        rigidbodyHero = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.collider.bounds.max.y <= gameObject.GetComponent<Collider2D>().bounds.min.y)
        {

            grounded = true;
            numberJump = sumJumps - 1;
            //Debug.Log(collision.gameObject.name);
        }
        
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && (numberJump > 0 || grounded))
        {
            rigidbodyHero.velocity = new Vector2(rigidbodyHero.velocity.x, 0);
            rigidbodyHero.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            numberJump -= 1;
        }

        move = Input.GetAxis("Horizontal");
        rigidbodyHero.velocity = new Vector2(move * maxSpeed, rigidbodyHero.velocity.y);
    }

   
 
}
