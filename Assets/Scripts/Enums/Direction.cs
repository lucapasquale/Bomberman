using UnityEngine;
using UnityEngine.Tilemaps;

public enum Directions
{
    Up,
    Down,
    Left,
    Right
}

public static class DirectionsExtensions {
    public static Vector3Int ToVector3Int(this Directions dir) {
        switch (dir) {
            case Directions.Up: return Vector3Int.up;
            case Directions.Down: return Vector3Int.down;
            case Directions.Left: return Vector3Int.left;
            case Directions.Right: return Vector3Int.right;

            default: return Vector3Int.zero;
        }
    }
}