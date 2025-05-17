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
        mentality = 60;
    }
    private void Start()
    {
        UpdateFace();
    }
    public override void Action()
    {
        base.Action();
    }

    public void DamagedHp(int damage)
    {
        if (hp - damage >= 0)
        {
            hp -= damage;
        }
    }
    public void DamagedMentality(int damage)
    {
        if (mentality - damage >= 0)
        {
            mentality -= damage;
        }
    }

    public void Attack()
    {
        if (courage == 100)
        {
            BattleManager.instance.attackBtn.interactable = true;
            BattleManager.instance.monster.gameObject.SetActive(false);
            BattleManager.instance.monster.Die();
        }
        else
        {
            BattleManager.instance.attackBtn.interactable = false;
        }
    }

    public void Turn()
    {
        if(BattleManager.instance.colleagues.Length == 0)
        {
            PlusCourage(20);
        }
    }

    public void Defense()
    {
        isDefend = true;
    }

    public void Run(int value)
    {
        if (mentality - value >= 0)
        {
            mentality -= value;
        }
        UpdateFace();
    }

    public void PlusMentality(int value)
    {
        if (mentality + value <= 100)
        {
            mentality += value;
        }
        UpdateFace();

    }
    public void PlusCourage(int value)
    {
        if (courage + value <= 100)
        {
            courage += value;
        }
    }

    public void Breathe()
    {
        isbreathe = true;
    }

    private void UpdateFace()
    {
        if (BattleManager.instance != null)
        {
            ChangeCondition(mentality, BattleManager.instance.characterImg[0], faceImg);
        }
        else if(GameManager.instance != null)
        {
            ChangeCondition(mentality, GameManager.instance.characterImg[0], faceImg);
        }
    }

    public override void ChangeCondition(int mentality, Image img, Sprite[] changeImg)
    {
        base.ChangeCondition(mentality, img, changeImg);
    }

    private void Update()
    {
        
    }
}
