using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : Monster
{
    private void Awake()
    {
        attackDamage = 50;
    }

    public void Attack()
    {
        Player player = BattleManager.instance.player;
        int damage = player.mentality / 2;
        player.DamagedMentality(damage);
    }
}
