using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionMob : MonoBehaviour {

    public string ID;
    DNA myDNA;
    public int hp, speed;
    Vector2 baseMoveVector1, baseMoveVector2, baseMoveVector3;
    Vector2 reactionBulletVector, reactionEnemyVector;

    

    int timeMoveVector;
    int reload;
    enum partMove { one = 1 ,two = 2, thr = 3 }
    partMove status;
    protected GameObject target;
    public GameObject[] parts;
    public Rigidbody2D myrg;
    // Use this for initialization
    void Start () {


        hp = myDNA.hp;
        speed = myDNA.speed;
        baseMoveVector1 = myDNA.baseMoveVector1;
        baseMoveVector2 = myDNA.baseMoveVector2;
        baseMoveVector3 = myDNA.baseMoveVector3;
        reactionBulletVector = myDNA.reactionBulletVector;
        reactionEnemyVector = myDNA.reactionEnemyVector;
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
        if (hp <= 0)
        {
            Destroy(gameObject, 0);
        }
        if (reload <= 0)
        {
            if ((int)status + 1 > 3)
            {
                status = (partMove) 1;
            }
            else
            {
                status = (partMove)((int)status + 1);
            }
            reload = timeMoveVector;
        }

        Vector3 move=new Vector3();

        if (status == partMove.one)
        {
            move = baseMoveVector1;
            reload--;
        }
        if (status == partMove.two)
        {
            move = baseMoveVector2;
            reload--;
        }
        if (status == partMove.thr)
        {
            move = baseMoveVector3;
            reload--;
        }
        if (target != null)
        {

        
        if (Vector3.Distance(target.transform.position, transform.position) < 3)
        {
            move = reactionEnemyVector;
        }

        //myrg.GetComponent<Rigidbody2D>().MovePosition(transform.TransformPoint((move + target.transform.position - transform.position).normalized));
        myrg.velocity = (move + target.transform.position - transform.position).normalized*speed;
        
       
        }

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
    public DNA GetDNA()
    {
        return myDNA; 
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }


}
