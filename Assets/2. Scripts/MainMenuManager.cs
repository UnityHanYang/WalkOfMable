using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI[] buttonTexts;

    void Start()
    {
        foreach (TextMeshProUGUI tmp in buttonTexts)
        {
            tmp.color = Color.white;
        }
    }

    public void OnStartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void OnExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
