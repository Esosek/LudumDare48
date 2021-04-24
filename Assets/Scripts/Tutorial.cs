using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    private void Awake() => instance = this;

    public GameObject[] tutorialTexts;

    int tutorialProgress = 0;

    private void Start()
    {
        tutorialTexts[0].SetActive(true);
    }

    public void NextTutorial()
    {
        tutorialTexts[tutorialProgress].SetActive(false);
        tutorialProgress++;
        tutorialTexts[tutorialProgress].SetActive(true);
    }
}
