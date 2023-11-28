
using UnityEngine;
public class CarController : MonoBehaviour
{
    private GameObject dropZone;
    private DropZone dropCard;
    private Car car;
    private void Start()
    {
        car = GetComponent<Car>();
        dropZone = GameObject.Find("DropCard");
        dropCard=dropZone.GetComponent<DropZone>();
    }
    public void MoveCarWithStep()
    {
        car.UpdateSprite();
        StartCoroutine(car.Move(dropCard.stepCard));
    }
    public void UpdateSpriteUp()
    {
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        if (car.IsEmpty())
        {
            spriteRenderer.sprite = car.Up[0];
        }
        else
        {
            spriteRenderer.sprite = car.Up[1];
        }
        car.CurrentDirection = Directions.Direction.Up;
    }
    public void UpdateSpriteDown()
    {
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        if(car.IsEmpty())
        {
            spriteRenderer.sprite = car.Down[0];
        }
        else
        {
            spriteRenderer.sprite = car.Down[1];
        }    
        car.CurrentDirection = Directions.Direction.Down;
    }
    public void UpdateSpriteLeft()
    {
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        if(car.IsEmpty())
        {
            spriteRenderer.sprite = car.Left[0];
        }    
        else
        {
            spriteRenderer.sprite = car.Left[1];
        }    
        car.CurrentDirection = Directions.Direction.Left;
    }
    public void UpdateSpriteRight()
    {
        SpriteRenderer spriteRenderer = car.GetComponent<SpriteRenderer>();
        if( car.IsEmpty())
        {
            spriteRenderer.sprite = car.Right[0];
        }
        else
        {
            spriteRenderer.sprite = car.Right[1];
        }
        car.CurrentDirection = Directions.Direction.Right;
    }

}