using UnityEngine.Events;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public UnityEvent _event;
    public ButtonManager buttonManager;
    private CarController carController;
    private GameObject carObject;
    private void Awake()
    {
        if(_event==null)
        {
            _event = new UnityEvent();
        }    
    }
    void Start()
    {
        carObject = GameObject.FindWithTag("Car");
        if(carObject != null)
        {
            carController = carObject.GetComponent<CarController>();
        }    
        
    }
    public void EnableEvent()
    {
        _event.AddListener(carController.MoveCarWithStep);
    }
    public void EnableEvent2()
    {
        _event.AddListener(buttonManager.ShowButtonDirection);
    }
    public void DisableEvent()
    {
        _event.RemoveAllListeners();
    }
}
