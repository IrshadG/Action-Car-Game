using UnityEngine;
using UnityEngine.UI;

public class TurretBehaviour : MonoBehaviour
{
    [SerializeField]private BaseGun selectedGun;                //Allows to access parameters of any gun
    [SerializeField]private Transform shootPosition;    //Where the bullet starts

    private GameObject bullet;
    private Transform target;

    private float health = 100f;

    [SerializeField] private Gradient gradient;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image barColor;

    private void Start()
    {
        barColor.color = gradient.Evaluate(100f);

        bullet = Resources.Load("Bullet/Bullet") as GameObject;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6 && target == null)
        {
            target = other.gameObject.transform;
            InvokeRepeating("ShootPlayer", 0, selectedGun.fireRate);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6 && target != null)
        {
            CancelInvoke("ShootPlayer");
            target = null;
        }
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 point = new Vector3(target.position.x, transform.position.y, target.position.z);

        Vector3 direction = point - transform.position;
        Quaternion _toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _toRotation, 2f * Time.deltaTime);
    }

    private void ShootPlayer()
    {
        GameObject newBullet = Instantiate(bullet, shootPosition.position, Quaternion.identity, null);
        newBullet.transform.rotation = transform.rotation;
        newBullet.GetComponent<BulletBehaviour>().bulletDamage = selectedGun.damageRate;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health;
        barColor.color = gradient.Evaluate(healthSlider.normalizedValue);

        if (health <= 0)
            TurretDestroyed();
    }

    public void TurretDestroyed()
    {
        //Add a blast
        
        //Destroy
        Destroy(gameObject);
        CarManager.instance.numberOfTurrets--;

        //Check for game over
        if(CarManager.instance.numberOfTurrets == 0)
        {
            //Game over
            CarManager.instance.OnGameOver();
        }
    }
}
