using UnityEngine;
using UnityEngine.UI;

public class MonsterVisualManager : MonoBehaviour
{
    public Image monsterImageUI;

    public Sprite[] area0Monsters; // 0±¸¿ª 1~4Ãþ ¸ó½ºÅÍ
    public Sprite[] area1Monsters; // 1±¸¿ª 1~4Ãþ ¸ó½ºÅÍ
    public Sprite[] area2Monsters; // 2±¸¿ª 1~5Ãþ ¸ó½ºÅÍ

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
            monsterImageUI.color = new Color(1, 1, 1, 1); // º¸ÀÌ°Ô
        }
        else
        {
            // ¸ó½ºÅÍ°¡ ¾ø´Â ÃþÀÌ¸é ¼û±â±â
            monsterImageUI.color = new Color(1, 1, 1, 0);
        }
    }
}
