using UnityEngine;

[CreateAssetMenu(fileName = "CardsCollectionData", menuName = "CardsCollectionData", order = 3)]
public class CardsCollectionData : ScriptableObject
{
    [SerializeField] CardData[] cardData;
    public CardData[] Collection { get => cardData;} 
}