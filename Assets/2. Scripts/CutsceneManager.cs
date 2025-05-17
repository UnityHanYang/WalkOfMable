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

    private int currentIndex = 0;  // �̹���/�ؽ�Ʈ ��Ʈ �ε���
    private int phase = 0;         // 0 = �̹���, 1 = �ؽ�Ʈ
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
                    // �ƾ� ���� �� Main ������ �̵�!
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

        // ȭ�� ��ü ��Ӱ� �� ���̵� ��
        yield return StartCoroutine(Fade(0, 1));

        if (phase == 0)
        {
            // [�̹��� ���� �ܰ�]
            imageDisplay.sprite = cutsceneImages[currentIndex];
            imageDisplay.color = new Color(1, 1, 1, 0); // ������ ���·� ����
            textDisplay.text = "";

            yield return StartCoroutine(Fade(1, 0)); // ȭ�� ��ü �����
            yield return StartCoroutine(FadeInImage(imageDisplay, 1f)); // �̹��� ������ ��Ÿ��

            canProceed = true;
        }
        else
        {
            // [�ؽ�Ʈ ���� �ܰ�]
            yield return StartCoroutine(FadeOutImage(imageDisplay, 0.3f)); // �̹��� �������
            yield return StartCoroutine(Fade(1, 0)); // ȭ�� ��ü �����

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
