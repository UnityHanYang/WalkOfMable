using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Animator animator;
    public Animator fadeAni;
    public Text message;

    void Start()
    {
        if(GameManager.areaCount == 1)
        {
            message.text = "발소리가 깊은 땅속으로 빠져나간다. 희미한 달빛이 나뭇잎을 창백하게 물들인다. 나는 이 길을 걸어내려간다. 언제까지? 다음날까지 살아남을 수는 있을까?";
        }
        else
        {
            message.text = "계속해서 어딘가로 가고 있다. 하지만 어디로 가는지는 이미 잊어버린지 오래다. 나는 여전히 이 길을 걸어내려간다.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WalkToClick()
    {
        animator.SetTrigger("walk");
        StartCoroutine(DelayToWalk());
    }

    IEnumerator DelayToWalk()
    {
        int num = Random.Range(3, 6);
        yield return new WaitForSeconds(num);
        fadeAni.SetTrigger("fadeIn");
        StartCoroutine(StoryInput());
    }    

    IEnumerator StoryInput()
    {
        yield return new WaitForSeconds(10);
    }    
}
