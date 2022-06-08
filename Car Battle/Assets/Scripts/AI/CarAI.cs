using UnityEngine;
using UnityEngine.AI;

public class CarAI : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Transform target;

    [SerializeField] private LayerMask layer;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(CarManager.instance.myCar != null)
            target = CarManager.instance.myCar.transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == layer)
            Debug.Log("Crashed with player");
    }
}
