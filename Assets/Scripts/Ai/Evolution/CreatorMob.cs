using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorMob : MonoBehaviour {

    public GameObject prefab;

    public GameObject Mob1, Mob2;

    int numberDNA=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BattleBegin()
    {
        Mob1 = CreateMob(generDNA());
        Mob2 = CreateMob(generDNA());


        Mob1.GetComponent<EvolutionMob>().SetTarget(Mob2);
        Mob2.GetComponent<EvolutionMob>().SetTarget(Mob1);

        Mob1.SetActive(true);
        Mob2.SetActive(true);
    }


    public GameObject CreateMob(DNA cDNA)
    {

        
        GameObject newobj = Instantiate(prefab, transform.position, transform.rotation);
        newobj.GetComponent<EvolutionMob>().SetDNA(cDNA, numberDNA+"");
        
        numberDNA++;

        return newobj;
    }

    public DNA generDNA()
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
    

}
