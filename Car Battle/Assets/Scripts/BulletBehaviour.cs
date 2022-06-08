using System.Collections;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float bulletLife = 5f;        //in Seconds
    private float bulletSpeed = 80f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Physics.IgnoreCollision(GetComponent<Collider>(), 
                                CarManager.instance.myCar.transform.GetChild(0).GetChild(0)
                                .GetComponent<Collider>());

        StartCoroutine(DeleteAfterDelay());
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log("Hit something! " + collision.gameObject.name);
        Destroy(gameObject);
    }

    private IEnumerator DeleteAfterDelay()
    {
        yield return new WaitForSeconds(bulletLife);

        Destroy(gameObject);
    }
}
