using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
    }
}
