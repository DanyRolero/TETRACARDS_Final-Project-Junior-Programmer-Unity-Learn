using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksGrid : MonoBehaviour
{
    private BlockData[,] blocks;

    //--------------------------------------------------------------------------------
    public void Initialize(Vector2Int size)
    {
        blocks = new BlockData[size.x, size.y];
    }

    //--------------------------------------------------------------------------------
    public BlockData this[int x, int y] => blocks[x, y];

    //--------------------------------------------------------------------------------
    public BlockData GetBlock(Vector3Int cell)
    {
        return blocks[cell.x, cell.y];
    }

    //--------------------------------------------------------------------------------
    public void SetCell(Vector3Int cell, BlockData block)
    {
        blocks[cell.x, cell.y] = block;
    }

    //--------------------------------------------------------------------------------
    public void UnsetCell(Vector3Int cell)
    {
        blocks[cell.x, cell.y] = null;
    }

    //--------------------------------------------------------------------------------
    public void ClearGrid()
    {
        CellsIterate((x, y, block) => blocks[x, y] = null);
    }

    //--------------------------------------------------------------------------------
    public bool IsCellOccupied(Vector3Int cell)
    {
        return blocks[cell.x, cell.y] != null;
    }

    //--------------------------------------------------------------------------------
    public bool IsEmptyBoard()
    {
        bool result = true;

        CellsIterate((x, y, block) =>
        {
            if (blocks[x, y] != null) result = false;
        });

        return result;
    }

    //--------------------------------------------------------------------------------
    public bool IsPolyminoCollision(PolyminoData polyminoData)
    {
        foreach (Vector3Int cell in polyminoData.Cells)
        {
            if (IsCellOccupied(cell)) return true;
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    public bool IsRowComplete(int row)
    {
        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            if (blocks[i, row] == null) return false;
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetRow(int row)
    {
        List<Vector3Int> rowPositions = new List<Vector3Int>();

        for (int x = 0; x < blocks.GetLength(0); x++)
        {
            rowPositions.Add(new Vector3Int(x, row, 0));
        }
        return rowPositions.ToArray();
    }

    //--------------------------------------------------------------------------------
    public bool AreEqualsTypeBlocks(Vector3Int[] blocksPositions)
    {
        if (blocksPositions.Length == 0) return false;

        BlockData sampleBlock = blocks[blocksPositions[0].x, blocksPositions[0].y];

        foreach (Vector3Int position in blocksPositions)
        {
            BlockData currentBlock = blocks[position.x, position.y];
            if (currentBlock == null || !currentBlock.Equals(sampleBlock))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public bool IsMonoTypeRow(int row)
    {
        BlockData sampleBlock = blocks[0, row];

        for (int x = 1; x < blocks.GetLength(0); x++)
        {
            if (blocks[x, row] == null || !blocks[x, row].Equals(sampleBlock))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public int CountSimilarsBlocksInBoard(Vector3Int blockPosition)
    {
        int count = 0;
        BlockData sampleBlock = blocks[blockPosition.x, blockPosition.y];
        if (sampleBlock == null) return count;
        CellsIterate((x, y, block) =>
        {
            if (blocks[x, y] != null && blocks[x, y].Equals(sampleBlock))
            {
                count++;
            }
        });

        return count;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetSimilarsBlocksPositions(BlockData sampleBlock)
    {
        List<Vector3Int> positions = new List<Vector3Int>();

        CellsIterate((x, y, block) =>
        {
            if (blocks[x, y] != null && blocks[x, y].Equals(sampleBlock))
            {
                positions.Add(new Vector3Int(x, y, 0));
            }
        });

        return positions.ToArray();
    }

    //--------------------------------------------------------------------------------
    public bool IsNonRepatedTypeBlocks(BlockData[] blocks)
    {
        HashSet<BlockData> uniqueBlocks = new HashSet<BlockData>();

        foreach (BlockData block in blocks)
        {
            if (block != null && !uniqueBlocks.Add(block))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int GetUppestCellUnsetPosition(int column)
    {
        for (int y = blocks.GetLength(1) - 1; y >= 0; y--)
        {
            if (blocks[column, y] == null)
            {
                return new Vector3Int(column, y, 0);
            }
        }

        return new Vector3Int(column, -1, 0);
    }

    public Vector3Int GetLowestCellUnsetPosition(int column)
    {
        for (int y = 0; y < blocks.GetLength(1); y++)
        {
            if (blocks[column, y] == null)
            {
                return new Vector3Int(column, y, 0);
            }
        }

        return new Vector3Int(column, blocks.GetLength(1), 0);
    }

    //--------------------------------------------------------------------------------
    public bool IsColumnFull(int column)
    {
        for (int y = 0; y < blocks.GetLength(1); y++)
        {
            if (blocks[column, y] == null) return false;
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public BlockData[] GetColumn(int column)
    {
        List<BlockData> columnBlocks = new List<BlockData>();
        for (int y = 0; y < blocks.GetLength(1); y++)
        {
            columnBlocks.Add(blocks[column, y]);
        }

        return columnBlocks.ToArray();
    }

    //--------------------------------------------------------------------------------
    public bool HasAdjacentBlock(Vector3Int cell, Vector3Int direction)
    {
        Vector3Int adjacentCell = cell + direction;

        if (!IsCellInBounds(adjacentCell))
        {
            return false;
        }

        return blocks[adjacentCell.x, adjacentCell.y] != null;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int GetAdjacentBlockPosition(Vector3Int cell, Vector3Int direction)
    {
        Vector3Int adjacentCell = cell + direction;

        if (!IsCellInBounds(adjacentCell))
        {
            throw new ArgumentOutOfRangeException("Adjacent cell is out of bounds.");
        }

        return adjacentCell;
    }

    //--------------------------------------------------------------------------------
    public bool IsAdjacentSimilarBlock(Vector3Int cell, Vector3Int direction)
    {
        
        Vector3Int adjacentBlock = GetAdjacentBlockPosition(cell, direction);
        if (adjacentBlock == null) return false;

        BlockData currentBlock = blocks[cell.x, cell.y];
        return currentBlock != null && currentBlock.Equals(adjacentBlock);
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetAdjacentsSimilarBlocksPositions(Vector3Int blockPosition)
    {
        List<Vector3Int> positions = new List<Vector3Int>();
        BlockData sampleBlock = blocks[blockPosition.x, blockPosition.y];

        if (sampleBlock == null) return positions.ToArray();

        Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

        foreach (Vector3Int direction in directions)
        {
            Vector3Int adjacentBlock = GetAdjacentBlockPosition(blockPosition, direction);
            if (blocks[adjacentBlock.x, adjacentBlock.y] != null && blocks[adjacentBlock.x, adjacentBlock.y].Equals(sampleBlock))
            {
                positions.Add(adjacentBlock);
            }
        }

        return positions.ToArray();
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetConnectedSimilarBlockPositions(Vector3Int blockPosition)
    {
        List<Vector3Int> connectedPositions = new List<Vector3Int>();
        BlockData sampleBlock = blocks[blockPosition.x, blockPosition.y];

        if (sampleBlock == null) throw new ArgumentNullException("Block at the given position is null.");

        Queue<Vector3Int> queue = new Queue<Vector3Int>();
        queue.Enqueue(blockPosition);

        while (queue.Count > 0)
        {
            Vector3Int currentPosition = queue.Dequeue();
            connectedPositions.Add(currentPosition);

            Vector3Int[] directions = { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

            foreach (Vector3Int direction in directions)
            {
                if (HasAdjacentBlock(currentPosition, direction))
                {
                    Vector3Int adjacentBlock = GetAdjacentBlockPosition(currentPosition, direction);
                    if (blocks[adjacentBlock.x, adjacentBlock.y].Equals(sampleBlock) && !connectedPositions.Contains(adjacentBlock))
                    {
                        queue.Enqueue(adjacentBlock);
                    }
                }
            }
        }

        return connectedPositions.ToArray();
    }

    //--------------------------------------------------------------------------------
    private bool IsCellInBounds(Vector3Int cell)
    {
        return cell.x >= 0 && cell.x < blocks.GetLength(0) && cell.y >= 0 && cell.y < blocks.GetLength(1);
    }

    //--------------------------------------------------------------------------------
    private void CellsIterate(Action<int, int, BlockData> callback)
    {
        for (int x = 0; x < blocks.GetLength(0); x++)
        {
            for (int y = 0; y < blocks.GetLength(1); y++)
            {
                callback(x, y, blocks[x, y]);
            }
        }
    }
}