
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{ 
    public EventManager _eventManager;

    internal int stepCard;
    public void OnDrop(PointerEventData eventData)
    {
        DragCard d = eventData.pointerDrag.GetComponent<DragCard>();
        if (d != null)
        {
            CardDisplay card = d.GetComponent<CardDisplay>();
            int.TryParse(card.stepText.text, out stepCard);
            if (stepCard != 0)
            {
                _eventManager.EnableEvent();
            }
            else if(stepCard == 0)
            {
                _eventManager.EnableEvent2();
            }
            _eventManager._event.Invoke();
            _eventManager.DisableEvent();
            Destroy(d.gameObject);
        }
    }
}