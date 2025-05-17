using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleTurn
{
    Player = 0,
    Colleague,
    Monster
}

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    public Player player;
    public Monster monster;
    public Colleague[] colleagues;

    public BattleTurn battleTurn;
    private int currentColleaguesIndex = 0;

    private void Awake()
    {
        instance = this;
        monster = FindAnyObjectByType<Monster>();
        player = FindAnyObjectByType<Player>();

        colleagues = FindObjectsOfType<Colleague>();
    }

    private void Start()
    {
        battleTurn = BattleTurn.Player;
        monster.Turn(5);
    }

    void Update()
    {
        //switch (battleTurn)
        //{
        //    case BattleTurn.Player:
        //        player.Turn();
        //        break;
        //    case BattleTurn.Colleague:
        //        colleagues[currentColleaguesIndex].Action();
        //        currentColleaguesIndex++;
        //        break;
        //    case BattleTurn.Monster:
        //        monster.Turn();
        //        break;
        //}
    }
}
