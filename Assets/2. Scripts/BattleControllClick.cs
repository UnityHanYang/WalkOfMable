using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControllClick : MonoBehaviour
{
    Player player;
    public GameObject MenuObj;
    public GameObject actionObj;

    private void Start()
    {
        if(BattleManager.instance.player != null)
        {
            player = BattleManager.instance.player;
        }
    }
    public void AttackClick()
    {
        player.Attack();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void DefenseClick()
    {
        player.Defense();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void ActionClick()
    {
        MenuObj.SetActive(false);
        actionObj.SetActive(true);
        player.Action();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void RunClick()
    {
        player.Run();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void PrayClick()
    {
        player.Pray();
        actionObj.SetActive(false);
        MenuObj.SetActive(true);
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void BreatheClick()
    {
        player.Breathe();
        actionObj.SetActive(false);
        MenuObj.SetActive(true);
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }

    public void BackClick()
    {
        actionObj.SetActive(false);
        MenuObj.SetActive(true);
    }
}
