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
        //if (BattleManager.instance != null)
        //{
        //    for (int i = 0; i < humans.Length; i++)
        //    {
        //        if (humans[i].TryGetComponent<Player>(out Player player))
        //        {
        //            int value = Player.mentality;
        //        }
        //        else
        //        {
        //            int value = Colleague.mentality;
        //            humans[i].ChangeCondition(value, characterImg[i], humans[i].faceImg);
        //        }
        //    }
        //}
    }
    public override void Action()
    {
        base.Action();
        BattleManager.instance.player.PlusCourage(15);
        BattleManager.instance.player.PlusMentality(15);
        BattleManager.instance.battleTurn = BattleTurn.Monster;
    }

    public void DamagedMentality(int value)
    {
        if (mentality - value >= 0)
        {
            mentality -= value;
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
