using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colleague : Human
{
    public override void Action()
    {
        BattleManager.instance.battleTurn = BattleTurn.Colleague;
        
        base.Action();
    }
}
