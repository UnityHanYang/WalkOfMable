using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Animator animator;
    public Button attackBtn;
    public Image[] characterImg;
    public Human[] humans;
    public BattleControllClick controllClick;

    public BattleTurn battleTurn;
    private int currentColleaguesIndex = 0;

    private void Awake()
    {
        instance = this;
        monster = FindAnyObjectByType<Monster>();
        player = FindAnyObjectByType<Player>();
        colleagues = FindObjectsOfType<Colleague>();
        humans = FindObjectsOfType<Human>();
    }

    private void Start()
    {
        battleTurn = BattleTurn.Player;
    }

    public void OpenAction()
    {
        animator.SetBool("isOpenAction", false);
        animator.SetBool("isCloseAction", false);
        animator.SetBool("isCloseMenu", true);
        animator.SetBool("isOpenAction", true);
    }
    public void OpenMenu()
    {
        animator.SetBool("isCloseAction", true);
        animator.SetBool("isCloseMenu", false);
    }
    public void CloseMenu()
    {
        animator.SetBool("isCloseMenu", true);
    }
    public void CloseAction()
    {
        animator.SetBool("isHideAction", true);
    }

    public void ChoiceMenu()
    {
        animator.SetBool("isOpenAction", false);
        animator.SetBool("isCloseMenu", false);
        animator.SetBool("isCloseAction", false);
        animator.SetBool("isHideAction", false);
    }

    void Update()
    {
        switch (battleTurn)
        {
            case BattleTurn.Player:
                player.Turn();
                break;
            case BattleTurn.Colleague:
                if(colleagues.Length > 0)
                {
                    controllClick.Cheering(currentColleaguesIndex);
                    colleagues[currentColleaguesIndex].Action();
                    currentColleaguesIndex = (currentColleaguesIndex + 1) >= colleagues.Length ? 0 : currentColleaguesIndex += 1;
                }
                break;
            case BattleTurn.Monster:
                CheckBoss();
                player.isDefend = false;
                player.isbreathe = false;
                break;
        }
    }

    private void CheckBoss()
    {
        if (TryGetComponent<Doctor>(out Doctor doctor))
        {
            doctor.Attack();
        }
        else
        {
            monster.Turn(1, player.isDefend, player.isbreathe);
        }
        //ChoiceMenu();
    }
}
