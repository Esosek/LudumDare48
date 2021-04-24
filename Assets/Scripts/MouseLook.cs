using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Camera mainCamera;
    Rigidbody rb;

    public Vector3 targetToLookAt;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            // Debug.Log("Mouse hit for " + hit.point);

            // get the point and set it's depth to player depth
            targetToLookAt = new Vector3(hit.point.x, hit.point.y, transform.position.z);

            // look at the point
            rb.MoveRotation(Quaternion.Euler(new Vector3(0, 90 * Mathf.Sign(targetToLookAt.x - transform.position.x), 0)));
        }
    }
}
