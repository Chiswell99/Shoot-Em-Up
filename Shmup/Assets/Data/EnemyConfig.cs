using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New EnemyConfig", menuName = "Enemies/Enemy config", order = 0)]

public class EnemyConfig : ScriptableObject
{
    public float moverSpeed;
    public Sprite sprite;
    public int score;
    public int health = 1;
    [Range(0, 1)]
    public float pickupChance;

    public bool ShouldThrowPicup()
    {
        return Dice.IsChanceSuccess(pickupChance);
    }
}


