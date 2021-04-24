using UnityEngine;

public class CartDeliver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cart"))
        {
            GoldManager.instance.ValidateCart();
        }
    }
}
