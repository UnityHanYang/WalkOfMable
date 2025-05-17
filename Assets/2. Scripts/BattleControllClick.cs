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
            messageText.text = "후라이팬을 든 손에 힘을 잔뜩 주고, 적을 향해 달려든다!";
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
            messageText.text = "가라테 자세를 취한다! (적의 육체 공격 데미지 경감)";
        }
    }
    public void RunEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "겁쟁이처럼 도망가긴! (아군 파티의 정신력 대폭 감소)";
        }
    }
    public void PrayEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "두 눈을 감은채로, 조심스레 기도문을 올린다... (정신력 회복)";
        }
    }
    public void BreatheEnter()
    {
        if (!isClick)
        {
            nameText.gameObject.SetActive(false);
            messageText.text = "깊게 숨을 들이마쉰다... 정신이 맑아지는 기분이다... (적의 정신 공격 데미지 경감)";
        }
    }
    public void Cheering(int index)
    {
        nameText.gameObject.SetActive(false);
        if (index == 0)
        {
            messageText.text = "리무가 활기찬 어조로 응원을 해줬다!";
        }
        else if (index == 1)
        {
            messageText.text = "모레는 내가 머뭇거리는 것을 보곤 웃음을 터트렸다!";
        }
        else if (index == 2)
        {
            messageText.text = "나우는 적의 약점을 설명해줬다!";
        }
    }

    public void FirstEnemyAttack(AttackType attackType)
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "1구역의 적";
        if(attackType == AttackType.physic)
        {
            messageText.text = "적 공격(물리) : 거대한 핏덩어리가 머리위로 날라온다.거대한 핏덩어리가 머리위로 날라온다.";
        }
        else
        {
            messageText.text = "적 공격(정신) : 수많은 짐승과 사람들의 비명소리가 섞여들려온다.";
        }
    }
    public void SecondEnemyAttack(AttackType attackType)
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "2구역의 적";

        if(attackType == AttackType.physic)
        {
            messageText.text = "적 공격(물리) : 괴물이 날카로운 이빨을 드러낸채 달려온다.";
        }
        else
        {
            messageText.text = "적 공격(정신) : 사람들의 날카로운 비명소리가 들려온다.";
        }
    }
    public void ThirdEnemyAttack()
    {
        nameText.gameObject.SetActive(true);
        nameText.text = "3구역의 적";
        int num = Random.Range(0, 4);

        switch(num)
        {
            case 0:
                messageText.text = "너... 너는 누구야! 이... 이 괴물! 그 무기 좀 내려놓고 말하지 그래";
                break;
            case 1:
                messageText.text = "우왓! 젠장... 또 너야? 하하... 내가 미쳤나보네...";
                break;
            case 2:
                messageText.text = "장난은 그만... 뭔가를 잘못 먹은걸거야... 관심이 필요한가본데?";
                break;
            case 3:
                messageText.text = "도플갱어? 이게 실존할 줄이야! 이건 전혀 논리적이지 않은데... 내가 저렇게 멍청하다니!";
                break;
        }
    }
}
