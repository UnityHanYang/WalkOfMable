using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature100 : Monster
{
    private void Awake()
    {
        attackDamage = 30;
    }

    public override void Turn(int area, bool isDefend, bool isbreathe, int damage)
    {
        base.Turn(area, isDefend, isbreathe, attackDamage);
    }
}
