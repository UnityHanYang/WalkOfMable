using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature0 : Monster
{
    private void Awake()
    {
        attackDamage = 10;
    }

    public override void Turn(int area, int damage)
    {
        base.Turn(area, attackDamage);
    }
}