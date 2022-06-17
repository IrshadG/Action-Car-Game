using System.Collections;
using UnityEngine;
using TMPro;
public class BulletBehaviour : MonoBehaviour
{
    private float bulletLife = 3f;        //in Seconds
    private float bulletSpeed = 0.9f;

    [SerializeField] private GameObject damageText;

    [System.NonSerialized] public float bulletDamage;       //Damage the bullet is carrying

    void Start()
    {
        StartCoroutine(DeleteAfterDelay());
    }

    void Update()
    {
        Vector3 newPos = transform.position + (transform.forward * 1f);
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos,bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) //player
        {
            Destroy(gameObject);
            CarManager.instance.TakeDamage(bulletDamage);
            ShowDamage(collision.transform);
        }
        else if (collision.gameObject.layer == 8 && !collision.collider.isTrigger) //turret
        {
            //Take damage to the turret
            collision.gameObject.GetComponentInChildren<TurretBehaviour>().TakeDamage(bulletDamage);
            Destroy(gameObject);
            ShowDamage(collision.transform);
        }
    }

    private void ShowDamage(Transform hitObj)
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        Vector3 textTransform = new Vector3(hitObj.position.x, hitObj.position.y + 2f, hitObj.position.z);
        
        GameObject newDamage = Instantiate(damageText, textTransform, rotation);
        //Get the damage amount from the bullet and show as text
        newDamage.GetComponent<TMP_Text>().text = bulletDamage.ToString();
    }

    private IEnumerator DeleteAfterDelay()
    {
        yield return new WaitForSeconds(bulletLife);

        Destroy(gameObject);
    }
}
