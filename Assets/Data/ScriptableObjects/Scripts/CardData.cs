using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData", order = 1)]
public class CardData : ScriptableObject
{
    public PolyminoData polymino;
    public Sprite image;
    public Tile tile;

    //Efectos
        // Efecto de posicionar en el tablero -> Previsualizable 
}