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
        messageText.text = "후라이팬을 든 손에 힘을 잔뜩 주고, 적을 향해 달려든다!";
    }
    public void BtnExit()
    {
        messageText.text = "";
    }
    public void DefenseEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "가라테 자세를 취한다! (적의 육체 공격 데미지 경감)";
    }
    public void RunEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "겁쟁이처럼 도망가긴! (아군 파티의 정신력 대폭 감소)";
    }
    public void PrayEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "두 눈을 감은채로, 조심스레 기도문을 올린다... (정신력 회복)";
    }
    public void BreatheEnter()
    {
        nameText.gameObject.SetActive(false);
        messageText.text = "깊게 숨을 들이마쉰다... 정신이 맑아지는 기분이다... (적의 정신 공격 데미지 경감)";
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
}
