using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlocksGrid : MonoBehaviour
{
    private BlockData[,] blocks;
    private const int EXTRA_FALL_ROWS = 6; // Extra rows for falling blocks, detect game over
    public int Width => blocks.GetLength(0);
    public int Height => blocks.GetLength(1);

    //--------------------------------------------------------------------------------
    public void Initialize(Vector2Int size)
    {
        blocks = new BlockData[size.x, size.y + EXTRA_FALL_ROWS];
    }

    //--------------------------------------------------------------------------------
    public BlockData[,] Blocks 
    {
        get { return blocks; }
        private set { blocks = value; }
    }

    //--------------------------------------------------------------------------------
    public BlockData this[int x, int y]
    {
        get 
        {
            CheckCellInBounds(x, y);
            return blocks[x, y]; 
        }
    }

    //--------------------------------------------------------------------------------
    public BlockData GetBlock(Vector3Int cell)
    {
        CheckCellInBounds(cell);
        return blocks[cell.x, cell.y];
    }

    //--------------------------------------------------------------------------------
    public Tile[,] GetTiles()
    {
        Tile[,] tiles = new Tile[Width, Height];

        CellsIterate((int x, int y, BlockData block) => {
            if(block != null) tiles[x,y] = blocks[x,y].Tile;
        });

        return tiles;
    }

    //--------------------------------------------------------------------------------
    public void SetCell(Vector3Int cell, BlockData block)
    {
        CheckCellInBounds(cell);
        blocks[cell.x, cell.y] = block;
    }

    //--------------------------------------------------------------------------------
    public void UnsetCell(Vector3Int cell)
    {
        CheckCellInBounds(cell);
        blocks[cell.x, cell.y] = null;
    }

    //--------------------------------------------------------------------------------
    public void PlaceBlocks(PlacedBlocks placedBlocks)
    {
        for (int i = 0; i < placedBlocks.Blocks.Length; i++)
        {
            Vector3Int cell = placedBlocks.Positions[i];
            CheckCellInBounds(cell);
            blocks[cell.x, cell.y] = placedBlocks.Blocks[i];
        }
    }

    //--------------------------------------------------------------------------------
    public void ClearGrid()
    {
        CellsIterate((x, y, block) => blocks[x, y] = null);
    }

    //--------------------------------------------------------------------------------
    public bool IsCellOccupied(Vector3Int cell)
    {
        CheckCellInBounds(cell);
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
            CheckCellInBounds(cell);
            if (IsCellOccupied(cell)) return true;
        }

        return false;
    }

    //--------------------------------------------------------------------------------
    public bool IsRowComplete(int row)
    {
        CheckCellInBounds(0, row);

        for (int i = 0; i < blocks.GetLength(0); i++)
        {
            if (blocks[i, row] == null) return false;
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetRow(int row)
    {
        CheckCellInBounds(0, row);

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
            CheckCellInBounds(position);
            BlockData currentBlock = blocks[position.x, position.y];
            if (currentBlock == null || !currentBlock.Equals(sampleBlock))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public bool IsMonoTypeBlockRow(int row)
    {
        CheckCellInBounds(0, row);

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
        CheckCellInBounds(blockPosition);

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
    public Vector3Int[] GetSimilarsBlocksPositions(Vector3Int blockPosition)
    {
        CheckCellInBounds(blockPosition);

        List<Vector3Int> positions = new List<Vector3Int>();
        BlockData sampleBlock = blocks[blockPosition.x, blockPosition.y];

        if (sampleBlock == null) return positions.ToArray();

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
    public bool IsNonRepeatedTypeBlockFullkRow(int row)
    {
        CheckCellInBounds(0, row);

        HashSet<BlockData> uniqueBlocks = new HashSet<BlockData>();

        for (int x = 0; x < blocks.GetLength(0); x++)
        {
            BlockData currentBlock = blocks[x, row];
            if (currentBlock == null) return false;

            if (!uniqueBlocks.Add(currentBlock))
            {
                return false;
            }
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int GetUppestCellUnsetPosition(int column)
    {
        CheckCellInBounds(column, 0);

        for (int y = blocks.GetLength(1) - 1; y >= 0; y--)
        {
            if (blocks[column, y] == null)
            {
                return new Vector3Int(column, y, 0);
            }
        }

        return new Vector3Int(column, -1, 0);
    }

    //--------------------------------------------------------------------------------
    public Vector3Int GetLowestCellUnsetPosition(int column)
    {
        CheckCellInBounds(column, 0);

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
        CheckCellInBounds(column, 0);

        for (int y = 0; y < blocks.GetLength(1); y++)
        {
            if (blocks[column, y] == null) return false;
        }

        return true;
    }

    //--------------------------------------------------------------------------------
    public Vector3Int[] GetColumn(int column)
    {
        CheckCellInBounds(column, 0);

        List<Vector3Int> columnPositions = new List<Vector3Int>();

        for (int y = 0; y < blocks.GetLength(1); y++)
        {
            columnPositions.Add(new Vector3Int(column, y, 0));
        }
        return columnPositions.ToArray();
    }

    //--------------------------------------------------------------------------------
    public bool HasAdjacentBlock(Vector3Int cell, Vector3Int direction)
    {
        CheckCellInBounds(cell);

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
        CheckCellInBounds(cell);

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
        CheckCellInBounds(cell);
        
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

    //--------------------------------------------------------------------------------
    private void CheckCellInBounds(Vector3Int cell)
    {
        if (!IsCellInBounds(cell))
        {
            throw new ArgumentOutOfRangeException($"Cell is out of bounds x: {cell.x}, y:{cell.y}.");
        }
    }

        //--------------------------------------------------------------------------------
    private void CheckCellInBounds(int x, int y)
    {
        if (!IsCellInBounds(new Vector3Int(x, y, 0)))
        {
            throw new ArgumentOutOfRangeException($"Cell is out of bounds x: {x}, y:{y}.");
        }
    }

    //--------------------------------------------------------------------------------
    private void CheckPositionIsNull(Vector3Int cell)
    {
        if (blocks[cell.x, cell.y] == null)
        {
            throw new ArgumentNullException($"Block at position x: {cell.x}, y:{cell.y} is null.");
        }
    }

    //--------------------------------------------------------------------------------
    private void CheckPositionIsNull(int x, int y)
    {
        if (blocks[x, y] == null)
        {
            throw new ArgumentNullException($"Block at position x: {x}, y:{y} is null.");
        }
    }

}