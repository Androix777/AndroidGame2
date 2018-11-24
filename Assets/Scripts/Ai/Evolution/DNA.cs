using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA  {




    public int hp, speed, damage, speedDamage;
    public Vector2 baseMoveVector1, baseMoveVector2, baseMoveVector3;
    //int scaleMoveVector1, scaleMoveVector2, scaleMoveVector3;
    public int timeMoveVector;
    public Vector2 reactionBulletVector, reactionEnemyVector;

    public bool[] parts = new bool[9];

    public int[] sizes = new int[9];

    public Vector2[] poss = new Vector2[9];



    public DNA(int hp, int speed, int damage, int speedDamage, int timeMoveVector,Vector2[] vectorsMove, bool[] parts, int[] sizes, Vector2[] poss)
    {
        this.hp = hp;
        this.speed = speed;
        this.damage = damage;
        this.speedDamage = speedDamage;
        this.timeMoveVector = timeMoveVector;

        baseMoveVector1 = vectorsMove[0];
        baseMoveVector2 = vectorsMove[1];
        baseMoveVector3 = vectorsMove[2];

        reactionBulletVector = vectorsMove[3];
        reactionEnemyVector = vectorsMove[4];

        this.parts = parts;
        this.sizes = sizes;
        this.poss = poss;

    }


}
