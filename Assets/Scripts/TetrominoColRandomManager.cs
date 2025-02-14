using UnityEngine;

public class TetrominoColRandomManager
{
    TetrominoCollection tetrominoCollection = new TetrominoCollection();
    public IntRandomCollection tetrominoShape = new IntRandomCollection(7);
    public IntRandomCollection width1Positions = new IntRandomCollection(10);
    public IntRandomCollection width2Positions = new IntRandomCollection(9);
    public IntRandomCollection width3Positions = new IntRandomCollection(8);
    public IntRandomCollection width4Positions = new IntRandomCollection(7);
    public IntRandomCollection I_variants = new IntRandomCollection(2);
    public IntRandomCollection O_variants = new IntRandomCollection(1);
    public IntRandomCollection T_variants = new IntRandomCollection(4);
    public IntRandomCollection S_variants = new IntRandomCollection(2);
    public IntRandomCollection Z_variants = new IntRandomCollection(2);
    public IntRandomCollection J_variants = new IntRandomCollection(4);
    public IntRandomCollection L_variants = new IntRandomCollection(4);

    //----------------------------------------------------------------------------------------------------
    public Tetromino GetRandomTetromino() 
    {
        int tetrominoShapeIndex = _GetRandomShapeIndex();
        int variantIndex = _GetRandomVariantIndex(tetrominoShapeIndex);
        Tetromino tetromino = tetrominoCollection.GetTetromino(tetrominoShapeIndex, variantIndex);
        int position = _GetRandomPosition(tetromino.Width);
        
        tetromino.Move(new Vector3Int(position, 0, 0));
        Debug.Log("Tetromino: " + tetrominoShapeIndex + " Variant: " + variantIndex + " Position: " + position + " Width: " + tetromino.Width);
        return tetromino;
    }

    //----------------------------------------------------------------------------------------------------
    private int _GetRandomShapeIndex()
    {
        return tetrominoShape.GetRandomInt();     
    }

    //----------------------------------------------------------------------------------------------------
    private int _GetRandomVariantIndex(int shapeIndex)
    {
        switch (shapeIndex)
        {
            case 0:
                return I_variants.GetRandomInt();
            case 1:
                return O_variants.GetRandomInt();
            case 2:
                return T_variants.GetRandomInt();
            case 3:
                return S_variants.GetRandomInt();
            case 4:
                return Z_variants.GetRandomInt();
            case 5:
                return J_variants.GetRandomInt();
            case 6:
                return L_variants.GetRandomInt();
            default:
                return -1;
        }
    }

    //----------------------------------------------------------------------------------------------------
    private int _GetRandomPosition(int width)
    {
        switch (width)
        {
            case 1:
                return width1Positions.GetRandomInt();
            case 2:
                return width2Positions.GetRandomInt();
            case 3:
                return width3Positions.GetRandomInt();
            case 4:
                return width4Positions.GetRandomInt();
            default:
                return -1;
        }
    }

}