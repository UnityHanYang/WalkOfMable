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

    // 먹기 버튼 클릭 → 선택창 열기
    public void EatClick()
    {
        menuUI.SetActive(false);
        eatItemUI.SetActive(true);
    }

    // 고기 선택 시 효과 적용
    public void EatMeatClick()
    {
        player.hp = Mathf.Min(Player.maxHp, player.hp + 30);
        player.hunger = Mathf.Min(Player.maxHunger, player.hunger + 30);
        player.mentality = Mathf.Min(Player.maxMentality, player.mentality + 20);
        ReturnToMenu();
    }

    // 동료 선택 시 효과 적용
    public void EatColleagueClick()
    {
        player.hp = Mathf.Min(Player.maxHp, player.hp + 20);
        player.hunger = Mathf.Min(Player.maxHunger, player.hunger + 20);
        player.mentality = Mathf.Max(0, player.mentality - 100);
        ReturnToMenu();
    }

    // 뒤로가기 → 원래 메뉴로 복귀
    public void BackFromEatMenu()
    {
        ReturnToMenu();
    }

    // 공통 복귀 함수
    void ReturnToMenu()
    {
        eatItemUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
