using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public float damage;
    public float speedFire;
    public float speedBullet;

    float damageMultipl { get; set; }
    float speedFireMultipl { get; set; }
    float speedBulletMultipl { get; set; }

    GameObject bullet;
    float reloaded;
    GameObject hero;
    GameObject room;
	// Use this for initialization
	void Start () {
        damageMultipl = 1;
        speedFireMultipl = 1;
        speedBulletMultipl = 1;
        bullet = gameObject.transform.GetChild(0).gameObject;
        hero = GameObject.FindGameObjectWithTag("Hero").gameObject;
        room = GameObject.FindGameObjectWithTag("Room").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = hero.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        Fire(difference.normalized);
        if (reloaded > 0 ) reloaded--;
    }

    virtual public void Fire(Vector3 moveVector)
    {   if (reloaded <= 0)
        {
            Debug.Log(moveVector * speedBullet * speedBulletMultipl);
            GameObject bull = Instantiate(bullet, transform.position,transform.rotation);
            bull.GetComponent<Bullet>().damage = damage * damageMultipl;
            bull.GetComponent<Bullet>().ally = false;
            if (room != null) { bull.transform.SetParent(room.transform); }         
            bull.SetActive(true);
            bull.GetComponent<Rigidbody2D>().AddForce(moveVector * speedBullet * speedBulletMultipl);
            reloaded = 100 - speedFire * speedFireMultipl;
        }
   
    }





}
