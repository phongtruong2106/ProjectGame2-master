using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newItemData", menuName = "Data/Position Data/Base Data")]
public class PositionPlayerData : ScriptableObject
{
    public Vector2 position;
    public string sceneName;
}
