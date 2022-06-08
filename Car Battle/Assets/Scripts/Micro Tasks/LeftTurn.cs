using UnityEngine;
using UnityEngine.EventSystems;

public class LeftTurn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        CarManager.instance.input = -1f;

        CarManager.instance.LFwheel.transform.Rotate(Vector3.left, -30f);
        CarManager.instance.RFwheel.transform.Rotate(Vector3.left, -30f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CarManager.instance.input = 0;

        CarManager.instance.LFwheel.transform.Rotate(Vector3.left, 30f);
        CarManager.instance.RFwheel.transform.Rotate(Vector3.left, 30f);
    }
}
