using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldControlClick : MonoBehaviour
{
    Player player;

    public GameObject menuUI;
    public GameObject eatItemUI;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // �Ա� ��ư Ŭ�� �� ����â ����
    public void EatClick()
    {
        menuUI.SetActive(false);
        eatItemUI.SetActive(true);
    }

    // ��� ���� �� ȿ�� ����
    public void EatMeatClick()
    {
        player.hp = Mathf.Min(Player.maxHp, player.hp + 30);
        player.hunger = Mathf.Min(Player.maxHunger, player.hunger + 30);
        player.mentality = Mathf.Min(Player.maxMentality, player.mentality + 20);
        ReturnToMenu();
    }

    // ���� ���� �� ȿ�� ����
    public void EatColleagueClick()
    {
        player.hp = Mathf.Min(Player.maxHp, player.hp + 20);
        player.hunger = Mathf.Min(Player.maxHunger, player.hunger + 20);
        player.mentality = Mathf.Max(0, player.mentality - 100);
        ReturnToMenu();
    }

    // �ڷΰ��� �� ���� �޴��� ����
    public void BackFromEatMenu()
    {
        ReturnToMenu();
    }

    // ���� ���� �Լ�
    void ReturnToMenu()
    {
        eatItemUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
