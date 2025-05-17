using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    physic = 0,
    spirit
}

public class Monster : MonoBehaviour
{
    protected int attackDamage = 1;
    public AttackType attackType;
    protected Player player;

    private void Awake()
    {
        attackType = AttackType.physic;
    }

    private void Start()
    {
        player = BattleManager.instance.player;
    }
    private void Attack(int area, int damage, bool isDefend, bool isbreathe)
    {
        ChoiceType(area);
        if (attackType == AttackType.physic && isDefend)
        {
            BattleManager.instance.player.DamagedHp((damage * area)/2);
        }
        else if(attackType == AttackType.spirit && isbreathe)
        {
            BattleManager.instance.player.DamagedMentality((damage * area) / 2);
        }
        else
        {
            if(attackType == AttackType.physic)
            {
                BattleManager.instance.player.DamagedHp(damage * area);
            }
            else
            {
                BattleManager.instance.player.DamagedMentality(damage * area);
            }
        }
    }

    private void ChoiceType(int area)
    {
        int num = Random.Range(0, area);

        attackType = (area - 1 == num) ? AttackType.physic : AttackType.spirit;
    }

    public virtual void Die()
    {

    }

    public virtual void Turn(int area, bool isDefend, bool isbreathe, int damage = 0)
    {
        Attack(area, damage, isDefend, isbreathe);
        BattleManager.instance.battleTurn = BattleTurn.Player;
    }
}
