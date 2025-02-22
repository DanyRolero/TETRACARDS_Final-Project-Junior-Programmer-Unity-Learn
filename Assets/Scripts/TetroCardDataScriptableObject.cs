using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TetroCardDataScriptableObject", menuName = "Mis SO/TetroCardDataScriptableObject", order = 0)]
public class TetroCardDataScriptableObject : ScriptableObject 
{
    public List<Sprite> images;
}