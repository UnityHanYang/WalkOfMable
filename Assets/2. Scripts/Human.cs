using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public Image currentImg;
    public Image[] faceImg;
    private bool isTop = true;
    private bool isMId = false;
    private bool isBot = false;
    
    public virtual void Action()
    {
        
    }

    public virtual void ChangeCondition(int mentality, Image originImg, Image[] changeImg)
    {
        if(mentality >= 70 && isTop)
        {
            originImg.sprite = changeImg[0].sprite;
            ChangeBool(false, true, true);
        }
        else if(mentality >= 30 && isMId)
        {
            originImg.sprite = changeImg[1].sprite;
            ChangeBool(true, false, true);
        }
        else if(mentality >= 0 && isBot)
        {
            originImg.sprite = changeImg[2].sprite;
            ChangeBool(true, true, false);
        }
    }

    private void ChangeBool(bool top, bool mid, bool bot)
    {
        isTop = top;
        isMId = mid;
        isBot = bot;
    }
}
