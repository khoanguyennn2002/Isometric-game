using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapManager : MonoBehaviour
{
    public CustomTile[] customTiles;
    public LevelLoader scene;
    public LevelManager levelManager;
    private Tilemap tileMap;
    private Car car;
    private Dictionary<Vector2Int, CustomTile> map = new Dictionary<Vector2Int, CustomTile>();
    private BoundsInt bounds;
    void Start()
    {
        tileMap = GetComponentInChildren<Tilemap>();
        car = GetComponentInChildren<Car>();
        if(tileMap !=null)
        {
            bounds = tileMap.cellBounds;
        }    
     
        Map();
      // DebugMap();
    }
    private void Map()
    {
        for (int z = bounds.max.z; z > bounds.min.z; z--)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    var tileLocation = new Vector3Int(x, y, z);
                    var tileKey = new Vector2Int(x, y);
                    if (tileMap.HasTile(tileLocation) && !map.ContainsKey(tileKey))
                    {
                        var tile = tileMap.GetTile(tileLocation);
                        for (int i = 0; i < customTiles.Length; i++)
                        {
                            if (customTiles[i].tile.name == tile.name)
                            {
                                map[tileKey] = customTiles[i];
                            }
                        }
                    }
                }
            }
        }
    }
    private void Delete(Directions.Direction d)
    {
        Vector2Int carTilePosition = car.GetCurrentPositon();
        Vector2Int TilePosition = carTilePosition + Directions.DIRS[(int)d];
        if (map.ContainsKey(TilePosition))
        {
            map.Remove(TilePosition);
            Vector3Int leftTilePosition3D = new Vector3Int(TilePosition.x, TilePosition.y, 2);
            tileMap.SetTile(leftTilePosition3D, null);
        }
    }
    public void DeleteAll()
    {
        Delete(Directions.Direction.Up);
        Delete(Directions.Direction.Left);
        Delete(Directions.Direction.Right);
        Delete(Directions.Direction.Down);
    }
    private void DebugMap()
    {
        foreach (var kvp in map)
        {
            Debug.Log($"Tile at position ({kvp.Key.x}, {kvp.Key.y}): {kvp.Value.tile.name}");
        }
    }
    public bool CheckCanMove(Vector2Int currentPosition, Vector2Int nextPosition)
    {
        if (map.ContainsKey(nextPosition))
        {
            if (car.CurrentDirection == Directions.Direction.Up)
            {
                if (map[currentPosition].canMoveUp && map[nextPosition].canMoveDown)
                {
                    return true;
                }
                return false;
            }
            else if (car.CurrentDirection == Directions.Direction.Down)
            {
                if (map[currentPosition].canMoveDown && map[nextPosition].canMoveUp)
                {
                    return true;
                }
                return false;
            }
            else if (car.CurrentDirection == Directions.Direction.Right)
            {
                if (map[currentPosition].canMoveRight && map[nextPosition].canMoveLeft)
                {
                    return true;
                }
                return false;
            }
            else if (car.CurrentDirection == Directions.Direction.Left)
            {
                if (map[currentPosition].canMoveLeft && map[nextPosition].canMoveRight)
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }
    public bool CheckNhanHang(Vector2Int currentPosition)
    {
        for(int i=0; i<4;i++)
        {
            Vector2Int checkTilePosition = currentPosition + Directions.DIRS[i];
            if (map.ContainsKey(checkTilePosition) && map[checkTilePosition].nhanHang)
            {
                return true;
            }
        } 
        return false;
    }
    public bool CheckGiaoHang(Vector2Int currentPosition)
    {
        for (int i = 0; i < 4; i++)
        {
            Vector2Int checkTilePosition = currentPosition + Directions.DIRS[i];
            if (map.ContainsKey(checkTilePosition) && map[checkTilePosition].giaoHang)
            {
                return true;
            }
        }
        return false;
    }

    public void CheckMoveFinish()
    {
        if (car.IsEmpty() && CheckNhanHang(car.GetCurrentPositon()))
        {
            car.SetEmpty(false);
            car.UpdateSprite();
        }
        else if (!car.IsEmpty() && CheckGiaoHang(car.GetCurrentPositon()))
        {
            car.SetEmpty(true);
            car.UpdateSprite();
            scene.LoadNextLevel();
            levelManager.UpdateCurrentLevel();
        }
    }
}