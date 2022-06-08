using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager instance;

    [System.NonSerialized] public GameObject myCar;
    [System.NonSerialized] public Transform LFwheel;
    [System.NonSerialized] public Transform RFwheel;

    public CarSelection carSelection;

    public float input;

    private float maxRotation;

    private void Awake()
    {
        //Singleton
        if(instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        carSelection = GetComponent<CarSelection>();

        //Load cars from asset directory through CarSelection class
        carSelection.LoadCars();

        maxRotation = CarSelection.instance.cars[CarSelection.instance.currentSelection].handling;
    }

    public void SpawnCar()
    {
        //Get car GameObject from array of scriptable objects containing details of each car and instantiate it
        myCar = Instantiate(carSelection.cars[carSelection.currentSelection].carPrefab, transform);

        RFwheel = myCar.transform.GetChild(0).GetChild(3);
        LFwheel = myCar.transform.GetChild(0).GetChild(4);

        GunManager.instance.SpawnGun();
    }

    public void HandleCar()
    {
        if(myCar != null)
            myCar.transform.Rotate(Vector3.up * input * maxRotation);
    }
}
