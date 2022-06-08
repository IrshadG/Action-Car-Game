using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager instance;

    private GameObject myGun;
    private GunSelection gunSelection;

    [System.NonSerialized]
    public Transform bulletSpawnPoint;
    private GameObject bullet;

    private void Awake()
    {
        //Singleton
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gunSelection = GetComponent<GunSelection>();

        //Load cars from asset directory through CarSelection class
        gunSelection.LoadGuns();

        //Load bullet object from assets 
        bullet = Resources.Load("Bullet/Bullet") as GameObject;
    }

    public void SpawnGun()
    {
        //Get the gun position gameobject (lol)
        Transform gunTarget = transform.GetChild(0).GetChild(0).GetChild(transform.GetChild(0).GetChild(0).childCount - 1);

        //Get car GameObject from array of scriptable objects containing details of each car and instantiate it
        myGun = Instantiate(gunSelection.guns[gunSelection.currentSelection].gunPrefab, gunTarget);
        myGun.transform.localPosition = Vector3.zero;
    }

    public void StartShooting()
    {
        InvokeRepeating("SpawnBullets", 0f, 0.3f);
    }

    public void StopShooting()
    {
        CancelInvoke("SpawnBullets");
    }

    private void SpawnBullets()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPoint);
        newBullet.transform.parent = null;
        newBullet.transform.localPosition = myGun.transform.GetChild(1).position;
        newBullet.transform.localRotation = myGun.transform.rotation;
    }
}
