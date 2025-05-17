using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTexts;
    public Animator animator;

    void Start()
    {
        foreach (TextMeshProUGUI tmp in buttonTexts)
        {
            tmp.color = Color.white;
        }
    }

    public void OnStartGame()
    {
        animator.SetTrigger("fadeIn");
    }

    public void OnExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
