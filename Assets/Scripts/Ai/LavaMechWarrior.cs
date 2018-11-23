using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMechWarrior : CreatureBoss
{
    enum statusBoss {FlyMoveFireL, FlyMoveFireR, FlyMoveFireC, FlyStopFireC, FlyStopFireR, FlyStopFireL , DownMove, DownMoveC, DownSkillOne, DownSkillTwo }

    statusBoss status = statusBoss.FlyStopFireC;

    enum skills {flyAndFireRL,flyToPointFire,DownFire }

    skills usesskills;

    enum point { right,left, сentre }

    point mypoint;

    public GameObject[] bullets;

    public int speedfire;
    int reload, timerRandom;
    int reloadedTeleport;
    public Vector3 move;
    int numbermove,timetofire;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Hero");
        maxhp = hp;
        status = statusBoss.FlyMoveFireR;
        move = Vector3.zero;

    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }
        if (timetofire > 0)
        {
            timetofire--;
        }

        
        if (timerRandom <= 0)
        {
            move = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100)).normalized * speed * speedMultiplu / 2;
            timerRandom = 30;
        }
        

        if (target != null)
        {
            if (usesskills == skills.flyToPointFire)
            {
                if (status == statusBoss.FlyStopFireC || status == statusBoss.FlyStopFireL || status == statusBoss.FlyStopFireR)
                {
                    if (numbermove < 3 )
                    {   if (timetofire < 1)
                        {
                            timetofire = 3600 / speedfire;
                            numbermove++;
                            FireAngleType(bullets[0], 180, 5, 180);           
                        }
                        move = Vector3.zero;
                    }
                    else
                    {
                        numbermove = 0;
                        SelectAttackOne();
                    }
                }
                else
                {
                    if (status == statusBoss.FlyMoveFireC)
                    {
                        move = ( Vector3.right * (11-transform.localPosition.x)).normalized;
                        Debug.Log(move);
                        if (gameObject.transform.localPosition.x >= 11 && gameObject.transform.localPosition.x <= 12)
                        {
                            move = Vector3.zero;
                            status = statusBoss.FlyStopFireC;
                            numbermove = 0;
                        }
                    }
                    if (status == statusBoss.FlyMoveFireL)
                    {
                        move = Vector3.left;
                        if (gameObject.transform.localPosition.x <= 1)
                        {
                            move = Vector3.zero;
                            status = statusBoss.FlyStopFireL;
                            numbermove = 0;
                        }
                    }
                    if (status == statusBoss.FlyMoveFireR)
                    {
                        move = Vector3.right;
                        if (gameObject.transform.localPosition.x >= 21)
                        {
                            move = Vector3.zero;
                            status = statusBoss.FlyStopFireR;
                            numbermove = 0;
                        }
                    }                    
                }
            }else
            {
                if (usesskills == skills.flyAndFireRL)
                {
                    if (status == statusBoss.FlyMoveFireL)
                    {
                        move = Vector3.left;
                        if (gameObject.transform.localPosition.x <= 1)
                        {
                            status = statusBoss.FlyMoveFireR;
                            numbermove ++;
                        }
                    }
                    if (status == statusBoss.FlyMoveFireR)
                    {
                        move = Vector3.right;
                        if (gameObject.transform.localPosition.x >= 21)
                        {
                            status = statusBoss.FlyMoveFireL;
                            numbermove ++;
                        }
                    }
                    if (numbermove > 3)
                    {
                        if (transform.localPosition.x>11)
                        {
                            status = statusBoss.FlyStopFireR;
                        }
                        numbermove = 0;
                        SelectAttackOne();
                    }
                }
                else
                {
                    if (status == statusBoss.DownMoveC)
                    {
                        move = (Vector3.right * (11 - transform.localPosition.x)).normalized;
                        if (gameObject.transform.localPosition.x >= 11 && gameObject.transform.localPosition.x <= 12)
                        {
                            if (numbermove > 3)
                            {
                                status = statusBoss.DownMove;
                                numbermove = 0;
                            }
                            else
                            {
                                if (timetofire < 1)
                                {
                                    timetofire = 3600/speedfire;
                                    numbermove++;
                                    FireAngleType(bullets[0], 180, 10, 180);
                                }
                            }
                            move = Vector3.zero;                                                     
                        }
                    }

                    if (status == statusBoss.DownMove)
                    {
                        move = Vector3.down ;
                        if (gameObject.transform.localPosition.y <= 16)
                        {
                            status = statusBoss.DownSkillOne;
                            move = Vector3.zero;
                        }
                    }
                    if (status == statusBoss.DownSkillOne)
                    {
                        move = Vector3.zero;
                        if (numbermove < 3)
                        {
                            if (timetofire < 1)
                            {
                                timetofire = 3600 / speedfire;
                                numbermove++;
                                FireAngleType(bullets[0], 0, 10, 180);
                            }
                            move = Vector3.zero;
                        }
                        else
                        {
                            numbermove = 0;
                            SelectAttackTwo();
                        }
                    }

                    if (status == statusBoss.DownSkillTwo)
                    {
                        move = Vector3.zero;
                        if (numbermove < 3)
                        {
                            if (timetofire < 1)
                            {
                                timetofire = 3600 / speedfire;
                                numbermove++;
                                FireAngleType(bullets[0], 0, 10, 180);
                            }
                            move = Vector3.zero;
                        }
                        else
                        {
                            numbermove = 0;
                            SelectAttackTwo();
                        }
                    }

                }
            }             
        }
        if (maxhp > hp*2 && usesskills != skills.DownFire)
        {
            SelectAttackTwo();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = move *speed *speedMultiplu;
    }

    void SelectAttackOne()
    {
        if (usesskills == skills.flyToPointFire)
        {
                usesskills = (skills)Random.Range(0,1);
                if (usesskills == skills.flyToPointFire)
                {
                    int numposin = ((int)mypoint + Random.Range(1, 2)) % 3;
                    mypoint = (point)numposin;
                    if (mypoint ==point.left)
                    {
                        status = statusBoss.FlyMoveFireL;
                    }
                    if (mypoint == point.right)
                    {
                        status = statusBoss.FlyMoveFireR;
                    }
                    if (mypoint == point.сentre)
                    {
                        status = statusBoss.FlyStopFireC;
                    }
                }
                else
                {
                    status = statusBoss.FlyMoveFireL;
                }         
        }
        else
        {
            usesskills = skills.flyToPointFire;
            mypoint = (point)Random.Range(0, 3);
            if (mypoint == point.left)
            {
            status = statusBoss.FlyMoveFireL;
            }
            if (mypoint == point.right)
            {
                status = statusBoss.FlyMoveFireR;
            }
            if (mypoint == point.сentre)
            {
            status = statusBoss.FlyMoveFireC;
            }            
        }
        Debug.Log(status + "  " + usesskills);
    }
    void SelectAttackTwo()
    {
        if (usesskills == skills.DownFire)
        {
            float rand = Random.Range(0,1);
            if (rand >= 0.5)
            {
                status = statusBoss.DownSkillOne;
            }
            else
            {
                status = statusBoss.DownSkillTwo;
            }
        }
        if (usesskills == skills.flyAndFireRL || usesskills == skills.flyToPointFire)
        {
            usesskills = skills.DownFire;
            status = statusBoss.DownMoveC;
            mypoint = point.сentre;
        }
        

    }

}
