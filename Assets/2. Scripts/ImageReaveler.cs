using UnityEngine;

public class ImageRevealer : MonoBehaviour
{
    public GameObject[] imageSlots;

    private int currentIndex = 0;

    void Start()
    {
        // 처음엔 전부 꺼두기
        foreach (GameObject img in imageSlots)
        {
            img.SetActive(false);
        }

        // 첫 번째만 보이게 하기
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
