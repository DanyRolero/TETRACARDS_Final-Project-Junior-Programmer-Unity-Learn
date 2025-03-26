using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData", order = 2)]
public class CardData : ScriptableObject
{
    [SerializeField] PolyminoData polymino;    
    public PolyminoData Polymino {get => polymino;}
    [SerializeField] Sprite cardImage;
    public Sprite Image {get => cardImage;}
    [SerializeField] BlockData[] blocks;
    public BlockData[] Blocks {get => blocks;}

    //Efectos
        // Efecto de posicionar en el tablero -> Previsualizable 
}