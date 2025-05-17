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

    private void Awake()
    {
        attackType = AttackType.physic;
    }

    private void Start()
    {

    }
    private void Attack(int area, int damage)
    {
        ChoiceType(area);
        BattleManager.instance.player.DamagedHp(damage * area);
    }

    private void ChoiceType(int area)
    {
        int num = Random.Range(0, area);

        attackType = (area - 1 == num) ? AttackType.physic : AttackType.spirit;
    }

    protected void Die()
    {

    }

    public virtual void Turn(int area, int damage = 0)
    {
        Attack(area, damage);
        BattleManager.instance.battleTurn = BattleTurn.Player;
    }

}
