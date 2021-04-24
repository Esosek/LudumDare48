using UnityEngine;

public class PickaxeThrow : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject pickaxePrefab;

    public bool hasThrown;


    // Update is called once per frame
    void Update()
    {
        // check if fire is pressed
        if (!Input.GetButtonDown("Fire1")) return;

        // check if you can throw
        if (hasThrown) return;

        spawnPoint.LookAt(GetComponent<MouseLook>().targetToLookAt);

        Instantiate(pickaxePrefab, spawnPoint.position, spawnPoint.rotation);
        hasThrown = true;
    }
}
