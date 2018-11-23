using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStormStatic : CreatureBoss
{
    public GameObject[] bullets;

    enum skills {first,second,third ,fourth ,fifth}
    skills activAttack;
    int[] skillsCoolDown = {50,50 };
    int numberAttack=0;
    int timeToNextfire;
    public int speedfire;
    int reload, timerRandom;
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

        if (target != null)
        {
            if (reload > 0) { reload --; }
            if (timeToNextfire > 0) { timeToNextfire--; }

            if (timeToNextfire <= 0)
            {
                if (activAttack == skills.first && numberAttack < 3)
                {
                    FireAngleType(bullets[0],0, 20,360);
                    timeToNextfire = 150;
                    numberAttack++;
                }
                if (activAttack == skills.second && numberAttack < 2)
                {
                    FireAngleType(bullets[0],270, 30 ,180);
                    timeToNextfire = 150;
                    numberAttack++;
                }
                if (activAttack == skills.third && numberAttack < 10)
                {
                    FireAngleType(bullets[0], 270 + numberAttack * 18, 10, 30);
                    timeToNextfire = 10;
                    numberAttack++;
                }
                if (activAttack == skills.fourth && numberAttack < 5)
                {
                    FireAngleType(bullets[0], 290 - 18 + numberAttack * 18  , 5, 30);
                    FireAngleType(bullets[0], 80 - 18 - numberAttack * 18  , 5, 30);
                    timeToNextfire = 20;
                    numberAttack++;
                }
                if (activAttack == skills.fifth && numberAttack < 5)
                {
                    FireAngleType(bullets[0], 360 - 18 + numberAttack * 18, 5, 30);
                    FireAngleType(bullets[0], 360 - 18 - numberAttack * 18, 5, 30);
                    timeToNextfire = 20;
                    numberAttack++;
                }
            }
            if (reload <= 0)
            {
                int w = Random.Range(0, 5);
                if (w == 0)
                {
                    activAttack = skills.first;
                    numberAttack = 0;
                }
                if (w == 1)
                {
                    activAttack = skills.second;
                    numberAttack = 0;
                }
                if (w == 2)
                {
                    activAttack = skills.third;
                    numberAttack = 0;
                }
                if (w == 3)
                {
                    activAttack = skills.fourth;
                    numberAttack = 0;
                }
                if (w == 4)
                {
                    activAttack = skills.fifth;
                    numberAttack = 0;
                }
                reload = 3600 / speedfire;
            }
           

        }
    }

}
