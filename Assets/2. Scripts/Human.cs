using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public Sprite[] faceImg;
    private bool isTop = true;
    private bool isMId = true;
    private bool isBot = true;
    
    public virtual void Action()
    {
        
    }

    public virtual void ChangeCondition(int mentality, Image img, Sprite[] changeImg)
    {
        if(mentality >= 70)
        {
            img.sprite = changeImg[0];
        }
        else if(mentality >= 30)
        {
            img.sprite = changeImg[1];
        }
        else if(mentality >= 0)
        {
            img.sprite = changeImg[2];
        }
    }
}
