using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    [System.NonSerialized] public GameObject target;
    [SerializeField] private Vector3 offset = new Vector3(-37, 23, 0);

    private CinemachineVirtualCamera cm;

    private void Awake()
    {
        //Singleton
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        cm = GetComponent<CinemachineVirtualCamera>();
    }

    public void CameraUpdate()
    {
        transform.position = target.transform.position + offset;
    }

    public void AssignCameraAim()
    {
        cm.LookAt = CarManager.instance.myCar.transform;
    }
}
