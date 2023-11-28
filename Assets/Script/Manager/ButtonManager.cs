using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private GameObject carObject;
    public List<GameObject> buttons= new List<GameObject>();
    
    private void Start()
    {
        carObject = GameObject.FindWithTag("Car");
        buttons[0].GetComponent<Button>().onClick.AddListener(OnClickLeft);
        buttons[1].GetComponent<Button>().onClick.AddListener(OnClickRight);
        buttons[2].GetComponent<Button>().onClick.AddListener(OnClickFront);
        buttons[3].GetComponent<Button>().onClick.AddListener(OnClickBack);
    }
    public void OnClickLeft()
    {
        carObject.GetComponent<CarController>().UpdateSpriteLeft();
        HideButtonDirection();
    }
    public void OnClickRight()
    {
        carObject.GetComponent<CarController>().UpdateSpriteRight();
        HideButtonDirection();
    }
    public void OnClickFront()
    {
        carObject.GetComponent<CarController>().UpdateSpriteUp();
        HideButtonDirection();
    }
    public void OnClickBack()
    {
        carObject.GetComponent<CarController>().UpdateSpriteDown();
        HideButtonDirection();
    }
    private void UpdateButtonPositions(float xOffset, float yOffset)
    {
        buttons[0].transform.position = new Vector3(carObject.transform.position.x - xOffset, carObject.transform.position.y - yOffset);
        buttons[1].transform.position = new Vector3(carObject.transform.position.x + xOffset, carObject.transform.position.y + yOffset);
        buttons[2].transform.position = new Vector3(carObject.transform.position.x + xOffset, carObject.transform.position.y - yOffset);
        buttons[3].transform.position = new Vector3(carObject.transform.position.x - xOffset, carObject.transform.position.y + yOffset);
    }
    public void ShowButtonDirection()
    {
        UpdateButtonPositions(0.35f, 0.2f);
        foreach (var btn in buttons)
        {
            btn.SetActive(true);
        }
    }
    public void HideButtonDirection()
    {
        foreach (var btn in buttons)
        {
            btn.SetActive(false);
        }
    }
}
