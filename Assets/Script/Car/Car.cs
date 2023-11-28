
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
public class Car : MonoBehaviour
{
 
    private bool isEmpty = true;
    public Sprite[] Up, Down, Right, Left;
    private Dictionary<Directions.Direction, Sprite[]> spriteDictionary;
    private Vector2Int positionAtMap;
    // viet script lv manager và chuyen CurrentDirection sang private và lay dirrection dua theo lv
    public Directions.Direction CurrentDirection;

    private Tilemap tilemap;
    private MapManager mapManager;
    public void Start()
    {
        tilemap = GetComponentInParent<Tilemap>();
        mapManager = GetComponentInParent<MapManager>();

        AddSpriteDictionary();
        GetCurrentPositon();
        UpdateSprite();
    }
    public void AddSpriteDictionary()
    {
        spriteDictionary = new Dictionary<Directions.Direction, Sprite[]>
        {
            { Directions.Direction.Up, Up },
            { Directions.Direction.Down, Down },
            { Directions.Direction.Left, Left },
            { Directions.Direction.Right, Right }
        };
    }    
    public Vector2Int GetCurrentPositon()
    {
        Vector3 carWorldPosition = transform.position;
        Vector3Int carCellPosition = tilemap.WorldToCell(carWorldPosition);
        positionAtMap = new Vector2Int(carCellPosition.x, carCellPosition.y);
        return positionAtMap;
    }
    public IEnumerator Move(int moveStep)
    {
        for (int i = 0; i < moveStep; i++)
        {
            Vector2Int nextTilePosition = GetCurrentPositon() + Directions.DIRS[(int)CurrentDirection];
            Vector3Int cellPosition = new Vector3Int(nextTilePosition.x, nextTilePosition.y, 2);
            if (mapManager.CheckCanMove(GetCurrentPositon(), nextTilePosition))
            {
                Vector3 worldPosition = tilemap.GetCellCenterWorld(cellPosition);
                transform.DOMove(worldPosition,0.15f);
                yield return new WaitForSeconds(0.155f);
                GetCurrentPositon();
            }
            else
            {
                Debug.Log("thua");
            }
        }
        mapManager.CheckMoveFinish();
    }
   
    public void UpdateSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(isEmpty)
        {
            spriteRenderer.sprite = spriteDictionary[CurrentDirection][0];
        }
        else
        {
            spriteRenderer.sprite = spriteDictionary[CurrentDirection][1];
        }
    }
    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void SetEmpty(bool value)
    {
        isEmpty = value;
    }    
}