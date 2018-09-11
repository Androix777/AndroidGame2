using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage ;
    public float speedFire ;
    public float speedBullet ;

    public float damageMultipl {private get;set;} 
    public float speedFireMultipl {private get;set;} 
    public float speedBulletMultipl {private get;set;} 

    float reloaded = 0;
    public GameObject bullet;
    Joystick control;

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        bullet = gameObject.transform.GetChild(0).gameObject;
        speedBullet = 100;


    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 moveVector = (Vector3.right * control.Horizontal + Vector3.up * control.Vertical);
        moveVector = moveVector.normalized;
        
        if (moveVector != Vector3.zero)
        {
           AngleGun(moveVector);
            if (reloaded <= 0)
            {
                Fire(moveVector);
            }
        }
        if (reloaded > 0) { reloaded--; }
	}
   
    virtual protected void AngleGun(Vector3 moveVector)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
    }

    virtual protected void Fire(Vector3 moveVector)
    {
        
        GameObject bull=Instantiate(bullet,transform.position,transform.rotation);
        bull.transform.SetParent(GameObject.FindGameObjectWithTag("Room").transform);
        Destroy(bull,5);
        bull.GetComponent<Bullet>().damage=damage*damageMultipl;
        bull.GetComponent<Bullet>().ally=true;
        bull.SetActive(true);
        bull.GetComponent<Rigidbody2D>().AddForce(speedBullet* moveVector*speedBulletMultipl);
        reloaded = 100 - speedFire;

    }

    public void GetStatsGun()
    {

    }

}
