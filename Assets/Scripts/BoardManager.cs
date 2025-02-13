using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
   public List<Tile> tiles;
   public Tilemap tilemap;

    private void Start() {
        tilemap.SetTile(new Vector3Int(0, 0, 0), tiles[1]);
        tilemap.SetTile(new Vector3Int(1, 1, 0), tiles[0]);
        Debug.Log(tilemap.GetTile(new Vector3Int(0, 0, 0)).name);
        Debug.Log(tilemap.HasTile(new Vector3Int(0, 0, 0)));

    }
}
