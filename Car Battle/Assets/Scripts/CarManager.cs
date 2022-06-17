using UnityEngine;
using UnityEngine.UI;
public class CarManager : MonoBehaviour
{
    public static CarManager instance;

    [System.NonSerialized] public GameObject myCar;
    [System.NonSerialized] public Transform LFwheel;
    [System.NonSerialized] public Transform RFwheel;

    public int numberOfTurrets = 4;
    private float maxRotation;
    public float input;

    [System.NonSerialized]
    public float playerHealth;
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private Gradient gradient;
    [SerializeField]
    private Image barColor;
    [SerializeField]
    private Shoot shootButton;

    [SerializeField]
    private GameObject turretMesh;
    [SerializeField]
    private GameObject turretContainer;
    public CarSelection carSelection;

    [System.NonSerialized]
    public Rigidbody rb;

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
        //Load cars from asset directory through CarSelection class
        carSelection.LoadCars();

        playerHealth = CarSelection.instance.cars[CarSelection.instance.currentSelection].maxHP;
        maxRotation = CarSelection.instance.cars[CarSelection.instance.currentSelection].handling;

        barColor.color = gradient.Evaluate(1f);     //1 is max
    }

    public void GameStarted()
    {
        SpawnCar();
        SpawnTurret();
    }

    public void SpawnCar()
    {
        //Get car GameObject from array of scriptable objects containing details of each car and instantiate it
        myCar = Instantiate(carSelection.cars[carSelection.currentSelection].carPrefab, transform);

        RFwheel = myCar.transform.GetChild(0).GetChild(3);
        LFwheel = myCar.transform.GetChild(0).GetChild(4);

        GunManager.instance.SpawnGun();
        rb = myCar.GetComponent<Rigidbody>();

    }

    public void SpawnTurret()
    {
        for(int i = 0; i < numberOfTurrets; i++)
        {
            Vector3 pos = Vector3.zero ;

            while (pos == Vector3.zero)
            {
                Vector3 newPos = new Vector3(Random.Range(30f, -50f), 10f, Random.Range(55f, -23f));

                RaycastHit hit;
                if(Physics.Raycast(newPos, Vector3.down, out hit))
                {
                    if(Physics.CheckSphere(hit.point,1.5f, 7))     //if there are walls in radius
                    {
                        pos = new Vector3(newPos.x, 0, newPos.z);
                        Instantiate(turretMesh, pos , Quaternion.identity, turretContainer.transform);
                    }
                }
            }
        }
    }

    public void HandleCar()
    {
        if (myCar != null)
        {
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * input * maxRotation);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        //myCar.transform.Rotate(Vector3.up * input * maxRotation);
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        healthSlider.value = playerHealth;

        barColor.color = gradient.Evaluate(healthSlider.normalizedValue);

        if(playerHealth <= 0)
        {
            OnGameOver();
        }
    }

    public void OnGameOver()
    {
        FindObjectOfType<GameManager>().OnChangeState();
        Destroy(myCar);
        Destroy(turretContainer);
        shootButton.StopInput();
    }
}
