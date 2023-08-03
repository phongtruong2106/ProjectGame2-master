using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttackDetail
{
    public Vector2 position;
    public float damageAmount;

    public void attackPhaseProtitel(float damge)
    {
        damageAmount += damge;
    }
}
