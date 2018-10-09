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

    public enum state { flyRight,fallRight,moveRight, stayRight, flyLeft, fallLeft, moveLeft, stayLeft }

    public state mystate;
    bool grounded = false;
    Rigidbody2D rigidbodyHero;
    int numberJump;
    float move;
    Animator animator;
    void Start()
    {
        //Hp = 100;
        //maxSpeed = 10;
        //sumJumps = 4;
        //jumpForce = 10;
        rigidbodyHero = gameObject.GetComponent<Rigidbody2D>();
        mystate = state.stayLeft;
        animator = GetComponent<Animator>();
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

        CheckMyState();
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


    private void CheckMyState()
    {
        if (grounded)
        {
            if (rigidbodyHero.velocity.x > 0)
            {
                mystate = state.moveRight;
                GetComponent<SpriteRenderer>().flipX = true;
                animator.SetInteger("mode", 1);
            }
            else
            if (rigidbodyHero.velocity.x < 0)
            {
                mystate = state.moveLeft;
                GetComponent<SpriteRenderer>().flipX = false;
                animator.SetInteger("mode", 1);
            }
            else
            if (rigidbodyHero.velocity.x == 0)
            {
                animator.SetInteger("mode", 0);
                if (mystate == state.moveLeft || mystate == state.flyLeft || mystate == state.fallLeft || mystate == state.stayLeft)
                {
                    mystate = state.stayLeft;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    mystate = state.stayRight;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
        else
        {
            if (rigidbodyHero.velocity.y > 0)
            {
                animator.SetInteger("mode", 2);
                if (rigidbodyHero.velocity.x > 0)
                {
                    mystate = state.flyRight;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                if (rigidbodyHero.velocity.x < 0)
                {
                    mystate = state.flyLeft;
                    GetComponent<SpriteRenderer>().flipX = false;
                }

                if (rigidbodyHero.velocity.x == 0)
                {
                    if (mystate == state.moveLeft || mystate == state.flyLeft || mystate == state.fallLeft || mystate == state.stayLeft)
                    {
                        mystate = state.flyLeft;
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        mystate = state.flyRight;
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
            }
            else
            {
                animator.SetInteger("mode", 3);
                if (rigidbodyHero.velocity.x > 0)
                {
                    mystate = state.fallRight;
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                if (rigidbodyHero.velocity.x < 0)
                {
                    mystate = state.fallLeft;
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                if (rigidbodyHero.velocity.x == 0)
                {
                    if (mystate == state.moveLeft || mystate == state.flyLeft || mystate == state.fallLeft || mystate == state.stayLeft)
                    {
                        mystate = state.fallLeft;
                        GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        mystate = state.fallRight;
                        GetComponent<SpriteRenderer>().flipX = true;
                    }
                }
            }
        }
    }
}


