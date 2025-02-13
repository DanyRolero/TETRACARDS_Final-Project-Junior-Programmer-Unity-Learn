using UnityEngine;

public class TetrominoColRandomManager
{
    TetrominoCollection tetrominoCollection = new TetrominoCollection();
    public IntRandomCollection tetrominoTypes = new IntRandomCollection(7);
    public IntRandomCollection width1Positions = new IntRandomCollection(10);
    public IntRandomCollection width2Positions = new IntRandomCollection(9);
    public IntRandomCollection width3Positions = new IntRandomCollection(8);
    public IntRandomCollection width4Positions = new IntRandomCollection(7);
    public IntRandomCollection I_variants = new IntRandomCollection(2);
    public IntRandomCollection L_variants = new IntRandomCollection(4);
    public IntRandomCollection J_variants = new IntRandomCollection(4);
    public IntRandomCollection O_variants = new IntRandomCollection(1);
    public IntRandomCollection S_variants = new IntRandomCollection(2);
    public IntRandomCollection Z_variants = new IntRandomCollection(2);
    public IntRandomCollection T_variants = new IntRandomCollection(4);

    //----------------------------------------------------------------------------------------------------
    public Tetromino GetRandomTetromino() 
    {
        int tetrominoTypesIndex = tetrominoTypes.GetRandomInt();
        int variantIndex;
        int width;
        int position;
        Tetromino tetromino;
        
        switch (tetrominoTypesIndex)
        {
            case 0:
                variantIndex = I_variants.GetRandomInt();
                break;
            case 1:
                variantIndex = O_variants.GetRandomInt();
                break;
            case 2:
                variantIndex = T_variants.GetRandomInt();
                break;
            case 3:
                variantIndex = S_variants.GetRandomInt();
                break;
            case 4:
                variantIndex = Z_variants.GetRandomInt();
                break;
            case 5:
                variantIndex = J_variants.GetRandomInt();
                break;
            case 6:
                variantIndex = L_variants.GetRandomInt();
                break;
            default:
                return null;
        }

        width = tetrominoCollection.GetTetromino(tetrominoTypesIndex, variantIndex).Width;

        switch (width)
        {
            case 1:
                position = width1Positions.GetRandomInt();
                break;
            case 2:
                position = width2Positions.GetRandomInt();
                break;
            case 3:
                position = width3Positions.GetRandomInt();
                break;
            case 4:
                position = width4Positions.GetRandomInt();
                break;
            default:
                return null;
        }

        tetromino = tetrominoCollection.GetTetromino(tetrominoTypesIndex, variantIndex);
        tetromino.Move(new Vector3Int(position, 0, 0));
        Debug.Log("Tetromino: " + tetrominoTypesIndex + " Variant: " + variantIndex + " Position: " + position);
        return tetromino;
    }

}