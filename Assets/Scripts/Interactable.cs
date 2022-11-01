using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Interactable : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private LockedAxis axis;
    private float mouseSen = 15f;

    private enum LockedAxis
    {
        x,
        y, 
        z
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 moveDir = Vector2.zero;

        switch (axis)
        {
            case LockedAxis.x:
                moveDir = transform.right * (eventData.delta.x * Time.deltaTime * mouseSen);
                break;

            case LockedAxis.y:
                moveDir = transform.up * (eventData.delta.y * Time.deltaTime * mouseSen);
                break;

            case LockedAxis.z:
                break;

            default:
                break;
        }
        
        this.transform.Translate(moveDir, Space.World);
    }
}
