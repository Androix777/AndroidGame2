using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionMob : MonoBehaviour {

    string ID;
    DNA myDNA;
    public int hp, speed;
    Vector2 baseMoveVector1, baseMoveVector2, baseMoveVector3;
    Vector2 reactionBulletVector, reactionEnemyVector;
    int timeMoveVector;
    protected GameObject target;
    public GameObject[] parts;

    // Use this for initialization
    void Start () {
        
        hp = myDNA.hp;
        speed = myDNA.speed;
        int i = 0;
		foreach(GameObject obj in parts)
        {

            if (myDNA.parts[i])
            {
                obj.GetComponent<ParentPart>().SetStats(myDNA.damage, myDNA.speed, ID, gameObject,target);
                obj.transform.localPosition = myDNA.poss[i];
                obj.transform.localScale *= myDNA.sizes[i];
                obj.SetActive(true);
            }
            i++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void SetDNA(DNA myDNA,string ID)
    {
       this.myDNA = myDNA;
        this.ID = ID;
    }
    public void GetDamage(int damage)
    {
        hp -= damage;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
