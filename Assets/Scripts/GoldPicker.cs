using UnityEngine;

public class GoldPicker : MonoBehaviour
{
    public GameObject goldInHand;
    public GameObject particleEffect;

    bool hasGold;

    private void OnTriggerEnter(Collider other)
    {
        // if colliding with gold
        if (other.CompareTag("Gold"))
        {
            // if you are not holding gold
            if (!hasGold)
            {
                Debug.Log("Gold picked up");

                hasGold = true;
                goldInHand.SetActive(true);
                Destroy(other.gameObject);

                // particles
                Instantiate(particleEffect, other.transform.position, Quaternion.identity);

                // sound fx
                AudioManager.instance.Play("GoldPickUp");

                // tutorial
                if (LevelManager.instance.activeSceneIndex == 1)
                {
                    Tutorial.instance.NextTutorial();
                }
            }

            else Debug.Log("Already have gold");

        }

        // if colliding with cart
        else if (other.CompareTag("Cart"))
        {
            // and has gold
            if (hasGold)
            {
                Debug.Log("Gold delivered to cart");

                hasGold = false;
                goldInHand.SetActive(false);

                // call to gold keeper that you delivered
                GoldManager.instance.DeliverGold();
            }
        }
    }
}
