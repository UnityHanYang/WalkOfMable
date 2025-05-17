using UnityEngine;
using UnityEngine.UI;

public class MonsterVisualManager : MonoBehaviour
{
    public Image monsterImageUI;

    public Sprite[] area0Monsters; // 0구역 1~4층 몬스터
    public Sprite[] area1Monsters; // 1구역 1~4층 몬스터
    public Sprite finalBossSprite; // 2구역 보스

    public void UpdateMonsterSprite(int area, int floor)
    {
        Sprite targetSprite = null;

        switch (area)
        {
            case 0:
                if (floor >= 0 && floor <= 3 && floor < area0Monsters.Length)
                    targetSprite = area0Monsters[floor];
                break;

            case 1:
                if (floor >= 0 && floor <= 3 && floor < area1Monsters.Length)
                    targetSprite = area1Monsters[floor];
                break;

            case 2:
                if (floor == 0) // 3구역은 1층만 있고, 그게 보스!
                    targetSprite = finalBossSprite;
                break;
        }

        if (targetSprite != null)
        {
            monsterImageUI.sprite = targetSprite;
            monsterImageUI.color = new Color(1, 1, 1, 1); // 보이게
        }
        else
        {
            // 몬스터가 없는 층이면 숨기기
            monsterImageUI.color = new Color(1, 1, 1, 0);
        }
    }
}
