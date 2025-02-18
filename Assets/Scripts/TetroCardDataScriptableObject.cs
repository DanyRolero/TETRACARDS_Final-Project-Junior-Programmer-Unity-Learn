using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TetroCardDataScriptableObject", menuName = "Mis SO/TetroCardDataScriptableObject", order = 0)]
public class TetroCardDataScriptableObject : ScriptableObject 
{
    public Sprite sprite;
    public Tetromino tetromino;    
}