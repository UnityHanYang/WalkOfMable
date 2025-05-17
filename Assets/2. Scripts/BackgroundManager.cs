using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image backgroundImageUI;         // 배경 UI 오브젝트
    public Sprite[] areaBackgroundSprites;  // 구역별 배경 스프라이트
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
        // 페이드 아웃
        yield return StartCoroutine(Fade(1f, 0f));

        // 스프라이트 변경
        if (area >= 0 && area < areaBackgroundSprites.Length)
        {
            backgroundImageUI.sprite = areaBackgroundSprites[area];
        }
        else
        {
            Debug.LogWarning("해당 구역에 맞는 배경이 없습니다!");
        }

        // 페이드 인
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
