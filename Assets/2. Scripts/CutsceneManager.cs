using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public Image imageDisplay;
    public TextMeshProUGUI textDisplay;
    public CanvasGroup fadePanel;

    public Sprite[] cutsceneImages;
    public string[] cutsceneTexts;

    public float fadeDuration = 1f;
    public float textSpeed = 0.05f;

    private int currentIndex = 0;  // 이미지/텍스트 세트 인덱스
    private int phase = 0;         // 0 = 이미지, 1 = 텍스트
    private bool isTyping = false;
    private bool canProceed = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        textDisplay.text = "";
        imageDisplay.color = Color.clear;
        StartCoroutine(PlayCutscenePhase());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                SkipTyping();
            }
            else if (canProceed)
            {
                phase++;
                if (phase > 1)
                {
                    currentIndex++;
                    phase = 0;
                }

                if (currentIndex < cutsceneImages.Length)
                {
                    StartCoroutine(PlayCutscenePhase());
                }
                else
                {
                    // 컷씬 종료 후 Main 씬으로 이동!
                    StartCoroutine(Fade(0, 1, () =>
                    {
                        SceneManager.LoadScene("Main");
                    }));
                }
            }
        }
    }

    IEnumerator PlayCutscenePhase()
    {
        canProceed = false;

        // 화면 전체 어둡게 → 페이드 인
        yield return StartCoroutine(Fade(0, 1));

        if (phase == 0)
        {
            // [이미지 등장 단계]
            imageDisplay.sprite = cutsceneImages[currentIndex];
            imageDisplay.color = new Color(1, 1, 1, 0); // 투명한 상태로 시작
            textDisplay.text = "";

            yield return StartCoroutine(Fade(1, 0)); // 화면 전체 밝아짐
            yield return StartCoroutine(FadeInImage(imageDisplay, 1f)); // 이미지 서서히 나타남

            canProceed = true;
        }
        else
        {
            // [텍스트 등장 단계]
            yield return StartCoroutine(FadeOutImage(imageDisplay, 0.3f)); // 이미지 사라지기
            yield return StartCoroutine(Fade(1, 0)); // 화면 전체 밝아짐

            imageDisplay.color = Color.clear;
            textDisplay.text = "";
            typingCoroutine = StartCoroutine(TypeText(cutsceneTexts[currentIndex]));
        }
    }


    IEnumerator TypeText(string message)
    {
        isTyping = true;
        foreach (char c in message)
        {
            textDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
        canProceed = true;
    }

    void SkipTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            textDisplay.text = cutsceneTexts[currentIndex];
            isTyping = false;
            canProceed = true;
        }
    }

    IEnumerator Fade(float from, float to, System.Action onComplete = null)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = to;
        onComplete?.Invoke();
    }

    IEnumerator FadeInImage(Image img, float duration)
    {
        Color color = img.color;
        color.a = 0;
        img.color = color;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(0f, 1f, elapsed / duration);
            img.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 1f;
        img.color = color;
    }
    IEnumerator FadeOutImage(Image img, float duration)
    {
        Color color = img.color;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
            img.color = color;
            elapsed += Time.deltaTime;
            yield return null;
        }

        color.a = 0f;
        img.color = color;
    }

}
