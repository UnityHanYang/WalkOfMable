using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleControllClick : MonoBehaviour
{
    Player player;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI messageText;

    private void Start()
    {
        if (BattleManager.instance.player != null)
        {
            player = BattleManager.instance.player;
        }
    }
    public void AttackClick()
    {
        player.Attack();
        BattleManager.instance.CloseMenu();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void DefenseClick()
    {
        player.Defense();
        BattleManager.instance.CloseMenu();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void ActionClick()
    {
        BattleManager.instance.OpenAction();
        player.Action();
    }
    public void RunClick()
    {
        player.Run(20);
        for (int i = 0; i < BattleManager.instance.colleagues.Length; i++)
        {
            BattleManager.instance.colleagues[i].DamagedMentality(20);
        }
        BattleManager.instance.CloseMenu();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void PrayClick()
    {
        player.PlusMentality(10);
        BattleManager.instance.CloseAction();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void BreatheClick()
    {
        player.Breathe();
        BattleManager.instance.CloseAction();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void BackClick()
    {
        BattleManager.instance.OpenMenu();
    }

    public void AttackEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "�Ķ������� �� �տ� ���� �ܶ� �ְ�, ���� ���� �޷����!";
    }
    public void BtnExit()
    {
        messageText.text = "";
    }
    public void DefenseEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "������ �ڼ��� ���Ѵ�! (���� ��ü ���� ������ �氨)";
    }
    public void RunEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "������ó�� ��������! (�Ʊ� ��Ƽ�� ���ŷ� ���� ����)";
    }
    public void PrayEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "�� ���� ����ä��, ���ɽ��� �⵵���� �ø���... (���ŷ� ȸ��)";
    }
    public void BreatheEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "��� ���� ���̸�����... ������ �������� ����̴�... (���� ���� ���� ������ �氨)";
    }
    public void Cheering(int index)
    {
        nameText.gameObject.SetActive(false);
        if (index == 0)
        {
            messageText.text = "������ Ȱ���� ������ ������ �����!";
        }
        else if (index == 1)
        {
            messageText.text = "�𷹴� ���� �ӹ��Ÿ��� ���� ���� ������ ��Ʈ�ȴ�!";
        }
        else if (index == 2)
        {
            messageText.text = "����� ���� ������ ���������!";
        }
    }
}
