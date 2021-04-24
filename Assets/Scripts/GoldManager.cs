using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager instance;

    private void Awake() => instance = this;

    public GameObject[] goldInCart;
    public ParticleSystem goldDeliverParticles;

    int goldNeeded;
    int goldCollected;

    // Start is called before the first frame update
    void Start()
    {
        // count gold ingame to pass
        GameObject[] goldInGame = GameObject.FindGameObjectsWithTag("Gold");
        goldNeeded = goldInGame.Length;
        Debug.Log("GOLD MANAGER: " + goldNeeded + " gold needed to pass");
    }

    public void DeliverGold()
    {
        // show gold in cart
        goldInCart[goldCollected].SetActive(true);
        // add it to total gold collected
        goldCollected++;
        // particles
        goldDeliverParticles.Play();

        // tutorial
        if (LevelManager.instance.activeSceneIndex == 1)
        {
            Tutorial.instance.NextTutorial();
        }
    }

    public void ValidateCart()
    {
        if (goldCollected >= goldNeeded)
        {
            Debug.Log("GOLD MANAGER: Cart successfuly delivered");

            // change to next level here
            LevelManager.instance.LoadNextLevel();
        }

        else Debug.Log("GOLD MANAGER: Not enough gold collected");
    }
}
