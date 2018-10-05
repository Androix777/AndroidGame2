using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hero : MonoBehaviour {
    public float dist;
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
        //Hp = 100;
        //maxSpeed = 10;
        //sumJumps = 4;
        //jumpForce = 10;
        rigidbodyHero = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
       


        if (collision.gameObject.tag == "Ground" && EnterGround())
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


        
        Debug.DrawRay(transform.position, Vector3.down * dist, Color.yellow);

       
        
    }

    public bool EnterGround()
    {

        RaycastHit2D[] objs = Physics2D.RaycastAll(transform.position, Vector3.down, dist);

        foreach (RaycastHit2D obj in objs)
        {
            if (obj.transform.tag == "Ground")
            {
                return true;
            }
        }
        return false;
    }

}
