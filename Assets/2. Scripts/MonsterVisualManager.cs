using UnityEngine;
using UnityEngine.UI;

public class MonsterVisualManager : MonoBehaviour
{
    public Image monsterImageUI;

    public Sprite[] area0Monsters; // 0���� 1~4�� ����
    public Sprite[] area1Monsters; // 1���� 1~4�� ����
    public Sprite[] area2Monsters; // 2���� 1~5�� ����

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
                if (floor >= 0 && floor <= 4 && floor < area1Monsters.Length)
                    targetSprite = area1Monsters[floor];
                break;
        }

        if (targetSprite != null)
        {
            monsterImageUI.sprite = targetSprite;
            monsterImageUI.color = new Color(1, 1, 1, 1); // ���̰�
        }
        else
        {
            // ���Ͱ� ���� ���̸� �����
            monsterImageUI.color = new Color(1, 1, 1, 0);
        }
    }
}
