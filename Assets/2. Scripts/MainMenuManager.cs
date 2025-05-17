using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnStartGame()
    {
        // "GameScene" �� �̸� Ȯ�� ��
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
