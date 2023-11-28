
using UnityEngine;
public class Directions : MonoBehaviour
{
    public static readonly Vector2Int[] DIRS = new[]
    {
        new Vector2Int(1, 0),   // Right
        new Vector2Int(0, -1),  // Up
        new Vector2Int(-1, 0),  // Left
        new Vector2Int(0, 1)    // Down
    };
    public enum Direction
    {
        Right,
        Up,
        Left,
        Down,
        Invalid
    }
}