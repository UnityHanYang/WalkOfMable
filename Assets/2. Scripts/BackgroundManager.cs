using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImageUI;         // ��� UI ������Ʈ
    public Sprite[] areaBackgroundSprites;  // ������ ��� ��������Ʈ
    public float fadeDuration = 1f;

    private Coroutine currentTransition;

    void Start()
    {
        StartCoroutine(FadeToArea(GameManager.area));
    }

    public void ChangeBackground(int area)
    {
        if (currentTransition != null)
            StopCoroutine(currentTransition);

        currentTransition = StartCoroutine(FadeToArea(area));
    }

    IEnumerator FadeToArea(int area)
    {
        // ���̵� �ƿ�
        yield return StartCoroutine(Fade(1f, 0f));

        // ��������Ʈ ����
        if (area >= 0 && area < areaBackgroundSprites.Length)
        {
            backgroundImageUI.sprite = areaBackgroundSprites[area];
        }
        else
        {
            Debug.LogWarning("�ش� ������ �´� ����� �����ϴ�!");
        }

        // ���̵� ��
        yield return StartCoroutine(Fade(0f, 1f));
    }

    IEnumerator Fade(float from, float to)
    {
        float elapsed = 0f;
        Color color = backgroundImageUI.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            color.a = alpha;
            backgroundImageUI.color = color;

            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = to;
        backgroundImageUI.color = color;
    }
}
