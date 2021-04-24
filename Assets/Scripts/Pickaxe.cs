using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 500f;

    public Transform gfx;
    public GameObject particles;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // avoid hitting player
        if (other.CompareTag("Player")) return;

        //Debug.Log("PICKAXE: Collided with " + other.gameObject.name);

        if (other.CompareTag("MovableRock"))
        {
            other.GetComponent<MovableRock>().InitFalling();
        }

        PickaxeThrow thrower = FindObjectOfType<PickaxeThrow>();
        thrower.hasThrown = false;

        // particles
        Instantiate(particles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void Update()
    {
        gfx.RotateAround(gfx.position, gfx.right, Time.deltaTime * rotationSpeed);
    }
}
