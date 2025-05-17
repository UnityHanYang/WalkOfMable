using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NexttoScene : MonoBehaviour
{
    public Text message;
    public void MovetoScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
