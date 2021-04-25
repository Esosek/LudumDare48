using System.Collections;
using UnityEngine;

public class MovableRock : MonoBehaviour
{
    public GameObject resetTutorial;
    public GameObject hitThisTutorial;

    Rigidbody rb;

    bool isFalling;
    bool alreadyFallen;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void InitFalling()
    {
        if (alreadyFallen) return;

        Debug.Log("Rock starts to fall");
        rb.isKinematic = false;
        StartCoroutine(EnablePhysics());

        // tutorial
        if (LevelManager.instance.activeSceneIndex == 2)
        {
            hitThisTutorial.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") && isFalling)
        {
            isFalling = false;
            rb.isKinematic = true;

            Debug.Log("Rock stopped falling");

            // sound fx
            AudioManager.instance.Play("RockFall");

            // tutorial
            if (LevelManager.instance.activeSceneIndex == 2)
            {
                resetTutorial.SetActive(true);
            }
        }
    }

    IEnumerator EnablePhysics()
    {
        yield return new WaitForSeconds(0.1f);
        isFalling = true;
        alreadyFallen = true;
    }
}
