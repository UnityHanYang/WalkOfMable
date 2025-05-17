using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleControllClick : MonoBehaviour
{
    Player player;

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
        player.Action();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
    public void RunClick()
    {
        player.Run();
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
    }
}
