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
        BattleManager.instance.player.DamagedMentality(Player.mentality - (Player.mentality/2));
    }
}
