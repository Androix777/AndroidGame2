using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сreature : MonoBehaviour {
    public float rangeVision;

    public int hp;
    public int hpMultiplu;
    protected GameObject target;

    public float speed;
    public float speedMultiplu;

    public float damage;
    public float damageMultiplu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void GetDamage(float d)
    {

    }
}
