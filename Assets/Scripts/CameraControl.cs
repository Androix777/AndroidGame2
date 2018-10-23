using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public CameraShake cam;

    public enum status { Menu, HeroLive, HeroDead}
    public GameObject hero;
    status mineStatus;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mineStatus == status.HeroLive)
        {
            transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, transform.position.z);
        }

	}

    public void startLvl()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        mineStatus = status.HeroLive;
    }
    public void deadHero()
    {
        mineStatus = status.HeroDead;
    }
    public void movetomenu()
    {
        transform.position = new Vector3(0,0, transform.position.z);
        mineStatus = status.Menu;
    }

    void cameraShake()
    {
        StartCoroutine(cam.Shake(1,1));
    }



}
