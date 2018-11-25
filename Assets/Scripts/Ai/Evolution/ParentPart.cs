using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPart : MonoBehaviour {
    protected int damage, speedDamage;
    protected GameObject god;
    public string ID;
    protected GameObject target;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetStats(int dam, int speed, string ID, GameObject lord, GameObject target)
    {
        damage = dam;
        speedDamage = speed;
        this.ID = ID;
        god = lord;
        this.target = target;
    }

    public virtual void GetDamage(int damage)
    {
        god.GetComponent<EvolutionMob>().hp -= damage;
    }

}
