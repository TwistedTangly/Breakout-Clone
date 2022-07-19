using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        rect.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        Debug.Log("Hover");
    }
   

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        rect.transform.localScale = new Vector3(1, 1, 1);
    }
}
