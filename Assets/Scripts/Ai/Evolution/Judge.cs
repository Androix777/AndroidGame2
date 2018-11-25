using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour {
    public GameObject creator;
    public GameObject prefab;

    public GameObject Mob1, Mob2;
    public DNA mob1DNA, mob2DNA;
    int numberDNA = 0;

    public int waitingTime, reload;
    public bool start;
    //public int age;
    DNA winner;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        reload--;
        if (start)
        {
            if (Mob1 == null)
            {
                winner = mob2DNA;
                retWin();
            }
            else
            {
                if (Mob2 == null)
                {
                    winner = mob1DNA;
                    retWin();
                }
            }
            if (reload <= 0)
            {
                if (Mob1.GetComponent<EvolutionMob>().hp / Mob1.GetComponent<EvolutionMob>().GetDNA().hp * 1f > Mob2.GetComponent<EvolutionMob>().hp / Mob2.GetComponent<EvolutionMob>().GetDNA().hp)
                {
                    winner = mob1DNA;
                    retWin();
                }
                else
                {
                    winner = mob2DNA;
                    retWin();
                }
            }
            
        }
        
    }

    public void BattleBegin(DNA FDNA, DNA SDNA)
    {
        mob1DNA = FDNA;
        mob2DNA = SDNA;
        start = true;
        Mob1 = CreateMob(FDNA);
        Mob2 = CreateMob(SDNA);

        Mob1.GetComponent<EvolutionMob>().SetTarget(Mob2);
        Mob2.GetComponent<EvolutionMob>().SetTarget(Mob1);

        Mob1.SetActive(true);
        Mob2.SetActive(true);
        reload = waitingTime;
    }

    public GameObject CreateMob(DNA cDNA)
    {
      
        GameObject newobj = Instantiate(prefab, transform.position, transform.rotation,transform);
        newobj.GetComponent<EvolutionMob>().SetDNA(cDNA, numberDNA + "");
        Vector3 pos = new Vector3(Random.Range(-4,4), Random.Range(-4, 4),0);
        
        newobj.transform.localPosition = pos;
        numberDNA++;

        return newobj;
    }

    public void retWin()
    {
        creator.GetComponent<CreatorMob>().setWinner(winner);
        Destroy(gameObject, 0);
    }
}
