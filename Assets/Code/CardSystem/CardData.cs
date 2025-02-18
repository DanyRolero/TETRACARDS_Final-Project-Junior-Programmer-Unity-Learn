public class CardData
{
    int tetrominoShapeIndex;
    Tetromino tetromino;
    int position;
    int[] tilesIndexes;

    public CardData(int tetrominoShapeIndex, Tetromino tetromino, int[] tilesIndexes)
    {
        this.tetrominoShapeIndex = tetrominoShapeIndex;
        this.tetromino = tetromino;
        this.position = tetromino.MinX;
        this.tilesIndexes = tilesIndexes;
    }
}
