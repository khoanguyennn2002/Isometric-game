
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCard : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private Transform parentTranform;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentTranform = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts=false;
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 0.15f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPos = new Vector3(eventData.position.x, eventData.position.y, 10f);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        transform.position = worldPos;

    }   
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentTranform);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, 1f);
    }
}