using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStorm : CreatureBoss
{

    public float maxX, maxY, minX, minY;

    public float rangeToStartPosition;
    public GameObject[] bullets;

    public int speedfire;
    int reload , timerRandom;
    int reloadedTeleport;
    Vector3 move;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
        
    }
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }

        if (target != null )
        {

            if (timerRandom <= 0)
            {
                move = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu / 2;
                timerRandom = 30;
            }
            if (timerRandom > 0) { timerRandom -= 1; }
            if (reloadedTeleport <= 0)
            {
                Jump(20);
                reloadedTeleport = 30;
            }
            if (reloadedTeleport > 0) { reloadedTeleport -= 1; }

            if (reload <= 0)
            {
                int w = Random.Range(0, 3);
                if (w == 0)
                {
                    FireAngleType(bullets[0],0,10,360);
                }
                if (w == 1)
                {
                    FireAngleType(bullets[0], 180, 10,180);
                }
                if (w == 2)
                {
                    FireAngleType(bullets[0], 180, 10,90);
                }
                reload = 30;
            }
            if (reload > 0) { reload -= 1; }

        }
        gameObject.GetComponent<Rigidbody2D>().velocity = move;
	}

    void Jump(float dist)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + Random.Range(-dist, dist),minX,maxX), Mathf.Clamp(transform.position.y + Random.Range(-dist, dist),minY,maxY), 0);

    }

    void controlPosition()
    {
        new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y , minY, maxY), 0);
    }
}
