using UnityEngine;
using UnityEngine.UI;

public class MonsterVisualManager : MonoBehaviour
{
    public Image monsterImageUI;
    public Image bossFullImageUI;

    public Sprite[] area0Monsters;
    public Sprite[] area1Monsters;
    public Sprite[] area2Monsters;

    public Sprite finalBossFullImage;

    public void UpdateMonsterSprite(int area, int floor)
    {
        // 초기화: 모두 숨기기
        monsterImageUI.color = new Color(1, 1, 1, 0);
        bossFullImageUI.color = new Color(1, 1, 1, 0);

        Sprite targetSprite = null;

        if (area == 0 && floor < area0Monsters.Length)
        {
            targetSprite = area0Monsters[floor];
            monsterImageUI.sprite = targetSprite;
            monsterImageUI.color = new Color(1, 1, 1, 1);
        }
        else if (area == 1 && floor < area1Monsters.Length)
        {
            targetSprite = area1Monsters[floor];
            monsterImageUI.sprite = targetSprite;
            monsterImageUI.color = new Color(1, 1, 1, 1);
        }
        else if (area == 2)
        {
            if (floor <= 3 && floor < area2Monsters.Length)
            {
                targetSprite = area2Monsters[floor];
                monsterImageUI.sprite = targetSprite;
                monsterImageUI.color = new Color(1, 1, 1, 1);
            }
            else if (floor == 4)
            {
                // 보스 등장!
                bossFullImageUI.sprite = finalBossFullImage;
                bossFullImageUI.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
