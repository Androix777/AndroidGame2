using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hero : MonoBehaviour {
    public float dist;
    public float Hp { get; set; }
    public float maxSpeed { get; set; }
    public float jumpForce { get; set; }
    public int sumJumps { get; set; }

    public enum state { flyRight,fallRight,moveRight, stayRight, flyLeft, fallLeft, moveLeft, stayLeft }

    public float ray;
    public state mystate;
    bool grounded = false;
    Rigidbody2D rigidbodyHero;
    int numberJump ,timetonextdamage;
    float move;
    Animator animator;

    Vector3 push;
    void Start()
    {
        Hp = 100;
        maxSpeed = 7;
        sumJumps = 2;
        jumpForce = 11;


        rigidbodyHero = gameObject.GetComponent<Rigidbody2D>();
        mystate = state.stayLeft;
        animator = GetComponent<Animator>();
    }


    private void CheakGrounded() {
        if (EnterGround())
        {
            grounded = true;
            numberJump = sumJumps;
 
        }
        else { grounded = false;  }
    }


    void Update()
    {

        Debug.DrawRay(transform.position, Vector3.down, Color.red, dist);
        CheakGrounded();

        if (timetonextdamage > 0)
        {
            timetonextdamage -= 1;
        }
       
        if (Input.GetKeyDown(KeyCode.W) && (numberJump > 0 || grounded))
        {
            rigidbodyHero.velocity = new Vector2(rigidbodyHero.velocity.x, 0);
            rigidbodyHero.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            numberJump -= 1;
        }
        
        move = Input.GetAxis("Horizontal");
        rigidbodyHero.velocity = new Vector2( move * maxSpeed + push.x, rigidbodyHero.velocity.y + push.y);

        if ((push.x > 0.7 || push.x < -0.7) && move * maxSpeed < Mathf.Abs(push.x))
        {
            push.x /= 1.1f;
        }
        else { push.x = 0; }
        if (push.y > 0.7 || push.y < -0.7)
        {
            push.y /= 1.1f;
        }else push.y = 0;

        CheckMyState();

        if (Hp <= 0)
        {
            DeadHero();
        }
    }

    public void DeadHero()
    {
        GameObject.FindGameObjectWithTag("ControlCam").GetComponent<CameraControl>().deadHero();
        Destroy(gameObject, 0);
    }

    public bool EnterGround()
    {
        Vector3 startpos = transform.position;
        startpos.x -= ray;

        RaycastHit2D[] objs = Physics2D.RaycastAll(startpos, Vector3.down, dist);

        foreach (RaycastHit2D obj in objs)
        {
            if (obj.transform.tag == "Ground")
            {
                Debug.Log("L");
                return true;
            }
        }

        startpos = transform.position;
        startpos.x += ray;

        objs = Physics2D.RaycastAll(startpos, Vector3.down, dist);

        foreach (RaycastHit2D obj in objs)
        {
            if (obj.transform.tag == "Ground")
            {
                Debug.Log("R");
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
    public void GetDamage(float loss )
    {
        if (timetonextdamage <= 0)
        {
            Hp -= loss;
            timetonextdamage = 30;
        }
        
    }



    public void Push(Vector3 force)
    {
        push = force;
    }

}


