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

    public enum state { fly,moveRight, moveLeft, stay }

    public float ray;
    public state mystate;
    bool grounded = false;
    Rigidbody2D rigidbodyHero;
    int numberJump ,timetonextdamage;
    float move;
    Animator animator;
    public SpriteRenderer sprite;
    Vector3 push;
    void Start()
    {
        Hp = 100;
        maxSpeed = 7;
        sumJumps = 2;
        jumpForce = 11;


        rigidbodyHero = gameObject.GetComponent<Rigidbody2D>();
        mystate = state.stay;
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

        //Debug.DrawRay(transform.position, Vector3.down, Color.red, dist);
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
        Debug.DrawRay(startpos, Vector3.down, Color.yellow, dist);
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
        Debug.DrawRay(startpos, Vector3.down, Color.green, dist);
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
                sprite.gameObject.transform.rotation = transform.rotation;
                mystate = state.moveRight;
                sprite.flipX = true;
                animator.SetInteger("mode", 1);
            }
            else
            if (rigidbodyHero.velocity.x < 0)
            {
                sprite.transform.rotation = transform.rotation;
                mystate = state.moveLeft;
                sprite.flipX = false;
                animator.SetInteger("mode", 1);
            }
            else
            if (rigidbodyHero.velocity.x == 0)
            {
                sprite.transform.rotation = transform.rotation;
                animator.SetInteger("mode", 0);
                if (mystate == state.moveLeft)
                {
                    mystate = state.stay;
                    sprite.flipX = false;
                }
                else
                {
                    mystate = state.stay;
                    sprite.flipX = true;
                }
            }
        }
        else
        {
            if (rigidbodyHero.velocity.y != 0)
            {
                animator.SetInteger("mode", 2);
                mystate = state.fly;
                sprite.flipX = false;
                Vector3 moveVector = new Vector3(rigidbodyHero.velocity.x, rigidbodyHero.velocity.y,0);
                moveVector = moveVector.normalized;
                sprite.transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
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


