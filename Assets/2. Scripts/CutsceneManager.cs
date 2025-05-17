using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    public Image imageDisplay;
    public TextMeshProUGUI textDisplay;
    public CanvasGroup fadePanel;

    public Sprite[] cutsceneImages;
    public string[] cutsceneTexts;

    public float fadeDuration = 1f;
    public float textSpeed = 0.05f;

    private int currentIndex = 0;
    private bool isTyping = false;
    private bool canProceed = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        StartCoroutine(PlayCutscene());
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
                if (currentIndex < cutsceneImages.Length)
                {
                    StartCoroutine(PlayCutscene());
                }
                else
                {
                    // ÄÆ¾À Á¾·á ¡æ ´ÙÀ½ ¾À ÀÌµ¿ µî
                    Debug.Log("ÄÆ¾À ³¡!");
                }
            }
        }
    }

    IEnumerator PlayCutscene()
    {
        canProceed = false;

        // ÆäÀÌµå ¾Æ¿ô
        yield return StartCoroutine(Fade(1, 0));

        // ÀÌ¹ÌÁö º¯°æ
        imageDisplay.sprite = cutsceneImages[currentIndex];

        // ÅØ½ºÆ® Ãâ·Â
        textDisplay.text = "";
        typingCoroutine = StartCoroutine(TypeText(cutsceneTexts[currentIndex]));

        // ÆäÀÌµå ÀÎ
        yield return StartCoroutine(Fade(0, 1));
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

    IEnumerator Fade(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(from, to, elapsed / fadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fadePanel.alpha = to;
    }
}
