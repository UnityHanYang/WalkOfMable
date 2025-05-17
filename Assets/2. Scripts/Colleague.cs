using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colleague : Human
{
    #region Á¤½Å·Â
    public static int mentality { get; private set; }
    #endregion
    private void Awake()
    {
        mentality = 100;
    }
    public override void Action()
    {
        base.Action();
        BattleManager.instance.battleTurn = BattleTurn.Monster;
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
