using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData", order = 2)]
public class CardData : ScriptableObject
{
    [SerializeField] PolyminoData polymino;    
    public PolyminoData Polymino {get; private set;}
    [SerializeField] Sprite cardImage;
    public Sprite Image {get; private set;}
    [SerializeField] BlockData[] blocks;
    public BlockData[] Blocks {get; private set;}

    //Efectos
        // Efecto de posicionar en el tablero -> Previsualizable 
}