using UnityEngine;

public class MoveCar : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = CarSelection.instance.cars[CarSelection.instance.currentSelection].maxSpeed;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
}
