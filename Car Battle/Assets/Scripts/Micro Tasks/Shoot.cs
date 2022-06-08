using UnityEngine.EventSystems;
using UnityEngine;

public class Shoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GunManager.instance.StartShooting();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GunManager.instance.StopShooting();
    }
}
