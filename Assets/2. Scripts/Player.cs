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

    #region 정신력
    public static int mentality { get; private set; }
    #endregion

    public bool isDefend = false;
    public bool isbreathe = false;

    private void Awake()
    {
        hp = 100;
        hunger = 100;
        courage = 0;
        mentality = 100;
    }
    public override void Action()
    {
        base.Action();
    }

    public void DamagedHp(int damage)
    {
        hp -= damage;
    }
    public void DamagedMentality(int damage)
    {
        mentality -= damage;
    }

    public void Attack()
    {
        if (courage == 100)
        {
            BattleManager.instance.monster.gameObject.SetActive(false);
            BattleManager.instance.monster.Die();
        }
    }

    public void Turn()
    {
    }

    public void Defense()
    {
        isDefend = true;
    }

    public void Run()
    {
        mentality -= 10;
    }

    public void Pray()
    {
        mentality += 10;
    }

    public void Breathe()
    {
        isbreathe = true;
    }

    public override void ChangeCondition(int mentality, Image originImg, Image[] changeImg)
    {
        base.ChangeCondition(mentality, originImg, changeImg);
    }

    private void Update()
    {
       // ChangeCondition(mentality, currentImg, faceImg);
    }
}
