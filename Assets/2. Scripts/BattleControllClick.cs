using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleControllClick : MonoBehaviour
{
    Player player;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI messageText;
    public bool isClick = false;

    private void Start()
    {
        if (BattleManager.instance.player != null)
        {
            player = BattleManager.instance.player;
        }
    }
    public void AttackClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            isClick = true;
            player.Attack();
            BattleManager.instance.CloseMenu();
            BattleManager.instance.battleTurn = BattleTurn.Colleague;
        }
    }
    public void DefenseClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            isClick = true;
            player.Defense();
            BattleManager.instance.CloseMenu();
            BattleManager.instance.battleTurn = BattleTurn.Colleague;
        }
    }
    public void ActionClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            BattleManager.instance.OpenAction();
            player.Action();
        }
    }
    public void RunClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            isClick = true;
            player.Run(20);
            for (int i = 0; i < BattleManager.instance.colleagues.Length; i++)
            {
                BattleManager.instance.colleagues[i].DamagedMentality(20);
            }
            BattleManager.instance.CloseMenu();
            BattleManager.instance.battleTurn = BattleTurn.Colleague;
        }
    }

    public void PrayClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            isClick = true;
            player.PlusMentality(10);
            BattleManager.instance.CloseAction();
            BattleManager.instance.battleTurn = BattleTurn.Colleague;
        }
    }

    public void BreatheClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            isClick = true;
            player.Breathe();
            BattleManager.instance.CloseAction();
            BattleManager.instance.battleTurn = BattleTurn.Colleague;
        }
    }

    public void BackClick()
    {
        if (BattleManager.instance.battleTurn == BattleTurn.Player)
        {
            BattleManager.instance.OpenMenu();
        }
    }

    public void AttackEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "�Ķ������� �� �տ� ���� �ܶ� �ְ�, ���� ���� �޷����!";
        }
    }
    public void BtnExit()
    {
        if (!isClick)
        {
            messageText.text = "";
        }
    }
    public void DefenseEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "������ �ڼ��� ���Ѵ�! (���� ��ü ���� ������ �氨)";
        }
    }
    public void RunEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "������ó�� ��������! (�Ʊ� ��Ƽ�� ���ŷ� ���� ����)";
        }
    }
    public void PrayEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "�� ���� ����ä��, ���ɽ��� �⵵���� �ø���... (���ŷ� ȸ��)";
        }
    }
    public void BreatheEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "��� ���� ���̸�����... ������ �������� ����̴�... (���� ���� ���� ������ �氨)";
        }
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

    public void FirstEnemyAttack(AttackType attackType)
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "1������ ��";
        if(attackType == AttackType.physic)
        {
            messageText.text = "�� ����(����) : �Ŵ��� �͵���� �Ӹ����� ����´�.�Ŵ��� �͵���� �Ӹ����� ����´�.";
        }
        else
        {
            messageText.text = "�� ����(����) : ������ ���°� ������� ���Ҹ��� ��������´�.";
        }
    }
    public void SecondEnemyAttack(AttackType attackType)
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "2������ ��";

        if(attackType == AttackType.physic)
        {
            messageText.text = "�� ����(����) : ������ ��ī�ο� �̻��� �巯��ä �޷��´�.";
        }
        else
        {
            messageText.text = "�� ����(����) : ������� ��ī�ο� ���Ҹ��� ����´�.";
        }
    }
    public void ThirdEnemyAttack()
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "3������ ��";
        int num = Random.Range(0, 4);

        switch(num)
        {
            case 0:
                messageText.text = "��... �ʴ� ������! ��... �� ����! �� ���� �� �������� ������ �׷�";
                break;
            case 1:
                messageText.text = "���! ����... �� �ʾ�? ����... ���� ���Ƴ�����...";
                break;
            case 2:
                messageText.text = "�峭�� �׸�... ������ �߸� �����ɰž�... ������ �ʿ��Ѱ�����?";
                break;
            case 3:
                messageText.text = "���ð���? �̰� ������ ���̾�! �̰� ���� �������� ������... ���� ������ ��û�ϴٴ�!";
                break;
        }
    }
}
