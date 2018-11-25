using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorMob : MonoBehaviour {
    public int leght;
    public GameObject prefabBattle;

    //public GameObject Mob1, Mob2;

    List<DNA> database =new List<DNA>();


    int numberDNA = 0;

    public int waitingTime,reload;
    public bool start;
    public int age;
    int retDNA;
    DNA winner;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    public void EvolutionBegin()
    {
        for (int i = 0;i< leght; i++)
        {
            for (int j = 0; j < leght; j++)
            {
                
                GameObject newobj = Instantiate(prefabBattle, transform.position, transform.rotation, transform.parent);
                newobj.GetComponent<Judge>().BattleBegin(CreateRandomDNA(20), CreateRandomDNA(20));
                Vector3 pos = new Vector3(i * 15, 10, 0);
                newobj.transform.localPosition = pos;
                numberDNA++;
                newobj.SetActive(true);
            }
        }

    }
    public void NextAgeBegin()
    {
        List<DNA> DNAList=new List<DNA>();
        foreach(DNA dn in database)
        {
            DNAList.Add(dn);
            if (Random.Range(0, 5) > 1)
            {
                DNAList.Add(Mutate(dn,5));
            }
            else
            {
                DNAList.Add(CreateRandomDNA(20));
            }
        }

        
        for (int i = 0; i < leght; i++)
        {
            for (int j = 0; j < leght; j++)
            {
                    
                    GameObject newobj = Instantiate(prefabBattle, transform.position, transform.rotation, transform.parent);
                    int number = Random.Range(0, DNAList.Count);
                    DNA fDNA = DNAList[number];
                    DNAList.RemoveAt(number);

                    number = Random.Range(0, DNAList.Count);
                    DNA sDNA = DNAList[number];
                    DNAList.RemoveAt(number);

                    newobj.GetComponent<Judge>().BattleBegin(fDNA, sDNA);
                    Vector3 pos = new Vector3(i * 15,j * 15, 0);
                    newobj.transform.localPosition = pos;
                    numberDNA++;
                    newobj.SetActive(true);
                
            }
        }
        database.Clear();
        retDNA = 0;
    }

    public DNA Mutate(DNA oldDNA, int points)
    {
        DNA newDNA = oldDNA;

        newDNA.RemovePoints(points);
        newDNA.AddPoints(points);
        return newDNA;
    }

    public DNA CreateRandomDNA(int points)
    {
        DNA newDNA = new DNA();
        newDNA.AddPoints(points);
        return(newDNA);
    }

    public void setWinner(DNA win)
    {
        if (retDNA < leght * leght)
        {
            database.Add(win);
            retDNA++;
        }
        if (retDNA >= leght * leght)
        {
            age++;
            NextAgeBegin();
        }
    }


    /*
    public DNA defaultDNA()
    {
        Vector2[] moveVector = new Vector2[5];
        moveVector[0] = new Vector2(1, 1);
        moveVector[1] = new Vector2(1, 1);
        moveVector[2] = new Vector2(1, 1);
        moveVector[3] = new Vector2(1, 1);
        moveVector[4] = new Vector2(1, 1);

        bool[] cheсkVector = new bool[5];
        cheсkVector[0] = true;
        cheсkVector[1] = true;
        cheсkVector[2] = true;
        cheсkVector[3] = true;

        int[] sizeVector = new int[5];
        sizeVector[0] = 1;
        sizeVector[1] = 1;
        sizeVector[2] = 1;
        sizeVector[3] = 1;

        Vector2[] possVector = new Vector2[5];
        possVector[0] = new Vector2(1, 1);
        possVector[1] = new Vector2(1, 1);
        possVector[2] = new Vector2(1, 1);
        possVector[3] = new Vector2(1, 1);



        DNA newDna = new DNA(1, 1, 1, 1, 1, moveVector, cheсkVector, sizeVector, possVector);
        return newDna;
    }
    */
    

}
