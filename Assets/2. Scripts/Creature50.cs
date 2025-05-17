using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature50 : Monster
{
    private void Awake()
    {
        attackDamage = 20;
    }

    public override void Turn(int area, int damage)
    {
        base.Turn(area, attackDamage);
    }
}
