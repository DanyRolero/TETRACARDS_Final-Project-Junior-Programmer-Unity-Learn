using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardSettings", menuName = "Settings/Board Settings", order = 0)]
public class BoardSettings : ScriptableObject
{
    [SerializeField] public Vector2Int gridSize;
}
