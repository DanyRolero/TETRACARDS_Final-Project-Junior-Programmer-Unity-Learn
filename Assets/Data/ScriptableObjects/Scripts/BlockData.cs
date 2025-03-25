using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "BlockData", menuName = "BlockData", order = 0)]
public class BlockData : ScriptableObject
{
    [SerializeField] Tile tile;
    public Tile Tile {get; private set;}
    [SerializeField] Tile previewTile;
    public Tile PreviewTile {get; private set;}

    //Añadir métodos de efectos
}