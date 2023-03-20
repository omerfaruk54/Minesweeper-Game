
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Unit myUnit;

    bool isLeftClick => Input.GetMouseButtonDown(0);
    bool isRightClick => Input.GetMouseButtonDown(1);

    public void OnPointerDown(PointerEventData eventData) // Elimizi bastýðýmýzda
    {

        if (isLeftClick)
        {
            myUnit.Open();
        }

        else if (isRightClick) 
        {
            Debug.Log("Flag");
            myUnit.ToggleFlag();        
        }

    }

    public void OnPointerUp(PointerEventData eventData)  //Elimizi kaldýrýdýðýmýzda
    {


    }
}
