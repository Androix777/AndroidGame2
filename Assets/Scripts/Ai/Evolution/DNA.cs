using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA  {
    const int MIN_VECTOR = -10;
    const int MAX_VECTOR = 10;
    const float MIN_VECTOR_PART = -0.5f;
    const float MAX_VECTOR_PART = 0.5f;
    const int NUM_PARTS = 9;
    const int MAX_HP = 5;
    const int MAX_SPEED = 5;
    const int MAX_DAMAGE = 5;
    const int MAX_SPEED_DAMAGE = 5;
    readonly int[] PARTS_PRICES = {2,2,2,2,2,2,2,2,2};
    readonly int[] PARTS_MAX_SIZES = {5,5,5,5,5,5,5,5,5};

    public int hp, speed, damage, speedDamage, points, freePoints, blockedPoints;
    public Vector2 baseMoveVector1, baseMoveVector2, baseMoveVector3;
    //int scaleMoveVector1, scaleMoveVector2, scaleMoveVector3;
    public int moveTime;
    public Vector2 reactionBulletVector, reactionEnemyVector;

    public bool[] parts = new bool[9];

    public int[] sizes = new int[9];

    public Vector2[] poss = new Vector2[9];

    public DNA () 
    {
        hp = 1;
        speed = 1;
        damage = 1;
        speedDamage = 1;
        points = 0;
        baseMoveVector1 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
        baseMoveVector2 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
        baseMoveVector3 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
        reactionBulletVector = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
        reactionEnemyVector = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
        moveTime = 100;
        for(int i = 0; i < NUM_PARTS; i++) 
        { 
            parts[i] = false;
            sizes[i] = 1; 
            poss[i] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
        }
    }

    public DNA(int hp, int speed, int damage, int speedDamage, int moveTime, Vector2[] vectorsMove, bool[] parts, int[] sizes, Vector2[] poss)
    {
        this.hp = hp;
        this.speed = speed;
        this.damage = damage;
        this.speedDamage = speedDamage;
        this.moveTime = moveTime;

        baseMoveVector1 = vectorsMove[0];
        baseMoveVector2 = vectorsMove[1];
        baseMoveVector3 = vectorsMove[2];

        reactionBulletVector = vectorsMove[3];
        reactionEnemyVector = vectorsMove[4];

        this.parts = parts;
        this.sizes = sizes;
        this.poss = poss;

    }

    public void AddPoints (int addedPoints)
    {
        freePoints = addedPoints;
        if(freePoints > 0)
        {
            switch(Random.Range(0,36))
            {
                case 1:
                    if(hp >= MAX_HP)
                    {
                        break;
                    }
                    else
                    {
                        hp++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 2:
                    if(hp >= MAX_SPEED)
                    {
                        break;
                    }
                    else
                    {
                        speed++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 3:
                    if(hp >= MAX_DAMAGE)
                    {
                        break;
                    }
                    else
                    {
                        damage++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 4:
                    if(hp >= MAX_SPEED_DAMAGE)
                    {
                        break;
                    }
                    else
                    {
                        speedDamage++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 5:
                    if(parts[0] || freePoints < PARTS_PRICES[0])
                    {
                        break;
                    }
                    else
                    {
                        parts[0] = true;
                        freePoints-=PARTS_PRICES[0];
                        points+=PARTS_PRICES[0];
                    }
                    break;
                case 6:
                    if(parts[1] || freePoints < PARTS_PRICES[1])
                    {
                        break;
                    }
                    else
                    {
                        parts[1] = true;
                        freePoints-=PARTS_PRICES[1];
                        points+=PARTS_PRICES[1];
                    }
                    break;
                case 7:
                    if(parts[2] || freePoints < PARTS_PRICES[2])
                    {
                        break;
                    }
                    else
                    {
                        parts[2] = true;
                        freePoints-=PARTS_PRICES[2];
                        points+=PARTS_PRICES[2];
                    }
                    break;
                case 8:
                    if(parts[3] || freePoints < PARTS_PRICES[3])
                    {
                        break;
                    }
                    else
                    {
                        parts[3] = true;
                        freePoints-=PARTS_PRICES[3];
                        points+=PARTS_PRICES[3];
                    }
                    break;
                case 9:
                    if(parts[4] || freePoints < PARTS_PRICES[4])
                    {
                        break;
                    }
                    else
                    {
                        parts[4] = true;
                        freePoints-=PARTS_PRICES[4];
                        points+=PARTS_PRICES[4];
                    }
                    break;
                case 10:
                    if(parts[5] || freePoints < PARTS_PRICES[5])
                    {
                        break;
                    }
                    else
                    {
                        parts[5] = true;
                        freePoints-=PARTS_PRICES[5];
                        points+=PARTS_PRICES[5];
                    }
                    break;
                case 11:
                    if(parts[6] || freePoints < PARTS_PRICES[6])
                    {
                        break;
                    }
                    else
                    {
                        parts[6] = true;
                        freePoints-=PARTS_PRICES[6];
                        points+=PARTS_PRICES[6];
                    }
                    break;
                case 12:
                    if(parts[7] || freePoints < PARTS_PRICES[7])
                    {
                        break;
                    }
                    else
                    {
                        parts[7] = true;
                        freePoints-=PARTS_PRICES[7];
                        points+=PARTS_PRICES[7];
                    }
                    break;
                case 13:
                    if(parts[8] || freePoints < PARTS_PRICES[8])
                    {
                        break;
                    }
                    else
                    {
                        parts[8] = true;
                        freePoints-=PARTS_PRICES[8];
                        points+=PARTS_PRICES[8];
                    }
                    break;
                case 14:
                    if(sizes[0] >= PARTS_MAX_SIZES[0])
                    {
                        break;
                    }
                    else
                    {
                        sizes[0]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 15:
                    if(sizes[1] >= PARTS_MAX_SIZES[1])
                    {
                        break;
                    }
                    else
                    {
                        sizes[1]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 16:
                    if(sizes[2] >= PARTS_MAX_SIZES[2])
                    {
                        break;
                    }
                    else
                    {
                        sizes[2]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 17:
                    if(sizes[3] >= PARTS_MAX_SIZES[3])
                    {
                        break;
                    }
                    else
                    {
                        sizes[3]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 18:
                    if(sizes[4] >= PARTS_MAX_SIZES[4])
                    {
                        break;
                    }
                    else
                    {
                        sizes[4]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 19:
                    if(sizes[5] >= PARTS_MAX_SIZES[5])
                    {
                        break;
                    }
                    else
                    {
                        sizes[5]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 20:
                    if(sizes[6] >= PARTS_MAX_SIZES[6])
                    {
                        break;
                    }
                    else
                    {
                        sizes[6]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 21:
                    if(sizes[7] >= PARTS_MAX_SIZES[7])
                    {
                        break;
                    }
                    else
                    {
                        sizes[7]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 22:
                    if(sizes[8] >= PARTS_MAX_SIZES[8])
                    {
                        break;
                    }
                    else
                    {
                        sizes[8]++;
                        freePoints--;
                        points++;
                    }
                    break;
                case 23:
                    poss[0] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 24:
                    poss[1] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 25:
                    poss[2] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 26:
                    poss[3] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 27:
                    poss[4] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 28:
                    poss[5] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 29:
                    poss[6] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 30:
                    poss[7] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 31:
                    poss[8] = new Vector2(Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART), Random.Range(MIN_VECTOR_PART, MAX_VECTOR_PART));
                    break;
                case 32:
                    baseMoveVector1 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
                    break;
                case 33:
                    baseMoveVector2 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
                    break;
                case 34:
                    baseMoveVector3 = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
                    break;
                case 35:
                    reactionBulletVector = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
                    break;
                case 36:
                    reactionEnemyVector = new Vector2(Random.Range(MIN_VECTOR, MAX_VECTOR), Random.Range(MIN_VECTOR, MAX_VECTOR));
                    break;
                default:
                    break;

            }
            if(freePoints>0) AddPoints(freePoints);
        }
    }

    public void RemovePoints (int minusPoints)
    {
        blockedPoints = minusPoints;
        if(blockedPoints > 0)
        {
            switch(Random.Range(0,36))
            {
                case 1:
                    if(hp <= 1)
                    {
                        break;
                    }
                    else
                    {
                        hp--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 2:
                    if(hp <= 1)
                    {
                        break;
                    }
                    else
                    {
                        speed--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 3:
                    if(hp <= 1)
                    {
                        break;
                    }
                    else
                    {
                        damage--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 4:
                    if(hp <= 1)
                    {
                        break;
                    }
                    else
                    {
                        speedDamage--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 5:
                    if((!parts[0]) || blockedPoints < PARTS_PRICES[0])
                    {
                        break;
                    }
                    else
                    {
                        parts[0] = false;
                        blockedPoints-=PARTS_PRICES[0];
                        points-=PARTS_PRICES[0];
                    }
                    break;
                case 6:
                    if((!parts[1]) || blockedPoints < PARTS_PRICES[1])
                    {
                        break;
                    }
                    else
                    {
                        parts[1] = false;
                        blockedPoints-=PARTS_PRICES[1];
                        points-=PARTS_PRICES[1];
                    }
                    break;
                case 7:
                    if((!parts[2]) || blockedPoints < PARTS_PRICES[2])
                    {
                        break;
                    }
                    else
                    {
                        parts[2] = false;
                        blockedPoints-=PARTS_PRICES[2];
                        points-=PARTS_PRICES[2];
                    }
                    break;
                case 8:
                    if((!parts[3]) || blockedPoints < PARTS_PRICES[3])
                    {
                        break;
                    }
                    else
                    {
                        parts[3] = false;
                        blockedPoints-=PARTS_PRICES[3];
                        points-=PARTS_PRICES[3];
                    }
                    break;
                case 9:
                    if((!parts[4]) || blockedPoints < PARTS_PRICES[4])
                    {
                        break;
                    }
                    else
                    {
                        parts[4] = false;
                        blockedPoints-=PARTS_PRICES[4];
                        points-=PARTS_PRICES[4];
                    }
                    break;
                case 10:
                    if((!parts[5]) || blockedPoints < PARTS_PRICES[5])
                    {
                        break;
                    }
                    else
                    {
                        parts[5] = false;
                        blockedPoints-=PARTS_PRICES[5];
                        points-=PARTS_PRICES[5];
                    }
                    break;
                case 11:
                    if((!parts[6]) || blockedPoints < PARTS_PRICES[6])
                    {
                        break;
                    }
                    else
                    {
                        parts[6] = false;
                        blockedPoints-=PARTS_PRICES[6];
                        points-=PARTS_PRICES[6];
                    }
                    break;
                case 12:
                    if((!parts[7]) || blockedPoints < PARTS_PRICES[7])
                    {
                        break;
                    }
                    else
                    {
                        parts[7] = false;
                        blockedPoints-=PARTS_PRICES[7];
                        points-=PARTS_PRICES[7];
                    }
                    break;
                case 13:
                    if((!parts[8]) || blockedPoints < PARTS_PRICES[8])
                    {
                        break;
                    }
                    else
                    {
                        parts[8] = false;
                        blockedPoints-=PARTS_PRICES[8];
                        points-=PARTS_PRICES[8];
                    }
                    break;
                case 14:
                    if(sizes[0] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[0]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 15:
                    if(sizes[1] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[1]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 16:
                    if(sizes[2] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[2]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 17:
                    if(sizes[3] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[3]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 18:
                    if(sizes[4] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[4]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 19:
                    if(sizes[5] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[5]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 20:
                    if(sizes[6] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[6]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 21:
                    if(sizes[7] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[7]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 22:
                    if(sizes[8] <= 1)
                    {
                        break;
                    }
                    else
                    {
                        sizes[8]--;
                        blockedPoints--;
                        points--;
                    }
                    break;
                case 23:
                    break;
                case 24:
                    break;
                case 25:
                    break;
                case 26:
                    break;
                case 27:
                    break;
                case 28:
                    break;
                case 29:
                    break;
                case 30:
                    break;
                case 31:
                    break;
                case 32:
                    break;
                case 33:
                    break;
                case 34:
                    break;
                case 35:
                    break;
                case 36:
                    break;
                default:
                    break;

            }
            if(blockedPoints>0) RemovePoints(blockedPoints);
        }
    }
}
