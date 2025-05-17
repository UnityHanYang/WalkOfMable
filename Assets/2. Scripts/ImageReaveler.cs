using UnityEngine;

public class ImageRevealer : MonoBehaviour
{
    public GameObject[] imageSlots;

    private int currentIndex = 0;

    void Start()
    {
        // ó���� ���� ���α�
        foreach (GameObject img in imageSlots)
        {
            img.SetActive(false);
        }

        // ù ��°�� ���̰� �ϱ�
        if (imageSlots.Length > 0)
        {
            imageSlots[0].SetActive(true);
            currentIndex = 1;
        }
    }

    public void ShowNextImage()
    {
        if (currentIndex < imageSlots.Length)
        {
            imageSlots[currentIndex].SetActive(true);
            currentIndex++;
        }
    }
}
