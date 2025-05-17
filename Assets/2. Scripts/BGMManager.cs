using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    public AudioSource audioSource;

    public AudioClip[] areaBGMs;   // ������ BGM
    public AudioClip battleBGM;    // ���� BGM

    private AudioClip currentBGM;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ���� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayAreaBGM(int area)
    {
        if (area >= 0 && area < areaBGMs.Length)
        {
            AudioClip bgm = areaBGMs[area];
            PlayBGM(bgm);
        }
    }

    public void PlayBattleBGM()
    {
        PlayBGM(battleBGM);
    }

    public void StopBGM()
    {
        audioSource.Stop();
        currentBGM = null;
    }

    private void PlayBGM(AudioClip bgm)
    {
        if (bgm != currentBGM)
        {
            audioSource.clip = bgm;
            audioSource.Play();
            currentBGM = bgm;
        }
    }
}
