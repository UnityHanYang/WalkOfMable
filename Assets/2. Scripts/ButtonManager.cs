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
            message.text = "�߼Ҹ��� ���� �������� ����������. ����� �޺��� �������� â���ϰ� �����δ�. ���� �� ���� �ɾ������. ��������? ���������� ��Ƴ��� ���� ������?";
        }
        else
        {
            message.text = "����ؼ� ��򰡷� ���� �ִ�. ������ ���� �������� �̹� �ؾ������ ������. ���� ������ �� ���� �ɾ������.";
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
