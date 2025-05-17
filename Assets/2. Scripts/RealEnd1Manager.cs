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

    public Sprite[] cutsceneImages;           // �̹��� ����
    public string[] cutsceneTexts;            // �ؽ�Ʈ ����
    public bool[] cutsceneIsText;             // true = �ؽ�Ʈ, false = �̹���

    public float fadeDuration = 1f;           // ��ü ȭ�� ���̵�
    public float textSpeed = 0.05f;           // Ÿ���� �ӵ�
    public float imageFadeDuration = 0.5f;    // �̹��� ������� �ӵ�

    private int currentIndex = 0;             // �� ������ �ε���
    private int imageIndex = 0;               // �̹��� �迭 �ε���
    private int textIndex = 0;                // �ؽ�Ʈ �迭 �ε���

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
                    // ������ �� �� �� Main ������ ��ȯ
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

        // ��ü ȭ�� ���̵� �� (�˰�)
        yield return StartCoroutine(Fade(0, 1));

        if (cutsceneIsText[currentIndex]) // �ؽ�Ʈ ��
        {
            imageDisplay.color = Color.clear;
            textDisplay.text = "";

            // ��ü ȭ�� ���̵� �ƿ� �� �ؽ�Ʈ Ÿ����
            yield return StartCoroutine(Fade(1, 0));
            typingCoroutine = StartCoroutine(TypeText(cutsceneTexts[textIndex]));
            textIndex++;
        }
        else // �̹��� ��
        {
            textDisplay.text = "";
            imageDisplay.sprite = cutsceneImages[imageIndex];
            imageDisplay.color = new Color(1, 1, 1, 0); // ������ �̹����� ����

            yield return StartCoroutine(Fade(1, 0)); // ��ü ȭ�� ������
            yield return StartCoroutine(FadeInImage(imageDisplay, imageFadeDuration)); // �̹��� �������

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
            textDisplay.text = cutsceneTexts[textIndex - 1]; // �̹� ����� index ����
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
