using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    float moveSpeed = 0.03f;

    private void Start()
    {
        Invoke("DestroyAfterDelay", 1f);
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed;
    }

    private void DestroyAfterDelay()
    {
        Destroy(gameObject);
    }
}
