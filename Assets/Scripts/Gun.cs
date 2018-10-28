using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {


    public float damage ;    
    public float speedBullet ;   
    public float speedFire ;

    public float damageMultipl {private get;set;}
    public float speedFireMultipl { private get; set; }


    float reloaded = 0;
    public bool ally{get;set;}

    GameObject bullet;

	// Use this for initialization
	void Start () {
        
        damageMultipl = 1;
        speedFireMultipl = 1;
        bullet=gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (reloaded > 0) { reloaded--; }
    }


    virtual public void Fire(Vector3 moveVector)
    {
        if (reloaded <= 0)
        {
            GameObject bull = Instantiate(bullet, transform.position, transform.rotation);
            bull.transform.SetParent(GameObject.FindGameObjectWithTag("Room").transform);
            Destroy(bull, 5);
            bull.GetComponent<Bullet>().damage = damage * damageMultipl;
            bull.GetComponent<Bullet>().ally = ally;
            bull.GetComponent<Bullet>().speed = speedBullet;
            bull.GetComponent<Bullet>().moveVector = moveVector;
            if (transform.parent.GetComponent<SpriteRenderer>() != null){
                bull.GetComponent<SpriteRenderer>().color = transform.parent.GetComponent<SpriteRenderer>().color;
            }
           
            bull.SetActive(true);

            reloaded = 100 - speedFire*speedFireMultipl;
        }

    }

    public void GetStatsGun()
    {

    }

}
