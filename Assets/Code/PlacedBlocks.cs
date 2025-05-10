using UnityEngine;

public class PlacedBlocks
{
    public BlockData[] Blocks { get; private set; }
    public Vector3Int[] Positions { get; private set; }

    public PlacedBlocks(BlockData[] blocks, Vector3Int[] positions)
    {
        if (blocks.Length != positions.Length)
        {
            throw new System.ArgumentException("Blocks and positions arrays must have the same length.");
        }

        this.Blocks = blocks;
        this.Positions = positions;
    }

    //--------------------------------------------------------------------------------
    public void SetBlockPosition(int index, Vector3Int newPosition)
    {
        Positions[index] = newPosition;
    }


}