using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Human
{
    // �������ͽ� �ִ�ġ (���ŷ��� �������� ����)
    public static int maxHp = 100;
    public static int maxHunger = 100;
    public static int maxMentality = 100;

    // ���� ���� �ν��Ͻ� ������ ���� (�ܺο��� ���� ����)
    public int hp { get; set; }
    public int hunger { get; set; }
    public int mentality { get; set; }
    public int courage { get; set; }

    public bool isDefend = false;
    public bool isbreathe = false;

    private void Awake()
    {
        hp = maxHp;
        hunger = maxHunger;
        mentality = maxMentality;
        courage = 0;
    }

    public override void Action()
    {
        base.Action();
    }

    public void DamagedHp(int damage)
    {
        hp = Mathf.Max(0, hp - damage);
    }

    public void DamagedMentality(int damage)
    {
        mentality = Mathf.Max(0, mentality - damage);
    }

    public void Attack()
    {
        if (courage >= 100)
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
        mentality = Mathf.Max(0, mentality - 10);
    }

    public void Pray()
    {
        mentality = Mathf.Min(maxMentality, mentality + 10);
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
        // ���� ���� �� �ʿ� �� ���
    }
}
