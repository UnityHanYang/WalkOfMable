using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Human
{
    #region 배고픔
    public static int hunger { get; private set; }
    #endregion

    #region 용기
    public static int courage { get; private set; }
    #endregion

    #region 체력
    public static int hp { get; private set; }
    #endregion

    private void Awake()
    {
        hp = 100;
        hunger = 100;
        courage = 0;
    }
    public override void Action()
    {
        base.Action();
    }

    public void DamagedHp(int damage)
    {
        hp -= damage;
    }

    public void Attack()
    {
        if (courage == 100)
        {
            BattleManager.instance.monster.gameObject.SetActive(false);
        }
    }

    public void Turn()
    {
        int a = 1;

        if (a == 1)
        {
            Attack();
        }
        else
        {
            Action();
        }
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public override void ChangeCondition(int mentality, Image originImg, Image[] changeImg)
    {
        base.ChangeCondition(mentality, originImg, changeImg);
    }

    private void Update()
    {
        ChangeCondition(mentality, currentImg, faceImg);
    }
}
