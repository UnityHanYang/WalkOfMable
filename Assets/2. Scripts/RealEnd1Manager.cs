using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RealEnd1Manager : MonoBehaviour
{
    public Image imageDisplay;
    public TextMeshProUGUI textDisplay;
    public CanvasGroup fadePanel;

    public Sprite[] cutsceneImages;           // 이미지 모음
    public string[] cutsceneTexts;            // 텍스트 모음
    public bool[] cutsceneIsText;             // true = 텍스트, false = 이미지

    public float fadeDuration = 1f;           // 전체 화면 페이드
    public float textSpeed = 0.05f;           // 타이핑 속도
    public float imageFadeDuration = 0.5f;    // 이미지 밝아지는 속도

    private int currentIndex = 0;             // 컷 순서용 인덱스
    private int imageIndex = 0;               // 이미지 배열 인덱스
    private int textIndex = 0;                // 텍스트 배열 인덱스

    private bool isTyping = false;
    private bool canProceed = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        textDisplay.text = "";
        imageDisplay.color = Color.clear;
        StartCoroutine(PlayCutsceneStep());
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
                currentIndex++;
                if (currentIndex < cutsceneIsText.Length)
                {
                    StartCoroutine(PlayCutsceneStep());
                }
                else
                {
                    // 마지막 컷 끝 → Main 씬으로 전환
                    StartCoroutine(Fade(0, 1, () => {
                        SceneManager.LoadScene("MainMenuScene");
                    }));
                }
            }
        }
    }

    IEnumerator PlayCutsceneStep()
    {
        canProceed = false;

        // 전체 화면 페이드 인 (검게)
        yield return StartCoroutine(Fade(0, 1));

        if (cutsceneIsText[currentIndex]) // 텍스트 컷
        {
            imageDisplay.color = Color.clear;
            textDisplay.text = "";

            // 전체 화면 페이드 아웃 → 텍스트 타이핑
            yield return StartCoroutine(Fade(1, 0));
            typingCoroutine = StartCoroutine(TypeText(cutsceneTexts[textIndex]));
            textIndex++;
        }
        else // 이미지 컷
        {
            textDisplay.text = "";
            imageDisplay.sprite = cutsceneImages[imageIndex];
            imageDisplay.color = new Color(1, 1, 1, 0); // 투명한 이미지로 시작

            yield return StartCoroutine(Fade(1, 0)); // 전체 화면 밝히기
            yield return StartCoroutine(FadeInImage(imageDisplay, imageFadeDuration)); // 이미지 밝아지기

            imageIndex++;
            canProceed = true;
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
            textDisplay.text = cutsceneTexts[textIndex - 1]; // 이미 진행된 index 기준
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
}
