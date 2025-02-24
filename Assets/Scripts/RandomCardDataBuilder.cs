using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomCardDataBuilder : MonoBehaviour
{
    public ITetrominoProvider tetrominoProvider;
    public Sprite[] cardImages;
    public Tile[] tiles;

    public Dictionary<int, ShuffleBagIndexes> xPositionsByTetrominoWsidth;
 

    void Start()
    {
        tetrominoProvider = new RandomizerTetrominoCollection();
        InitializeXPositionByTetrominosWidth();

    }

    private InitializeXPositionByTetrominosWidth()
    {
        xPositionsByTetrominoWsidth = new Dictionary<int, ShuffleBagIndexes>();
        int columnsOnGridBoard = GameObject.FindGameObjectWithTag("GridBoard").GetComponent<SpriteRenderer>().size.x;

        foreach (Tetromino tetromino in tetrominoProvider.tetrominos)
        {
            if (!xPositionsByTetrominoWsidth.ContainsKey(tetromino.Width))
            {
                xPositionsByTetrominoWsidth.Add(tetromino.Width, new ShuffleBagIndexes(columnsOnGridBoard - tetromino.Width));
            }
        }
    }
}