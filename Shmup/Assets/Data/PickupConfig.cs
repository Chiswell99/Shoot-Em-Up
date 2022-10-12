using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    None,
    Laser,
    Shield,
}

[CreateAssetMenu(fileName = "New PickupConfig", menuName = "Player/Pickups Config", order = 1)]
public class PickupConfig : ScriptableObject
{
    public int score;
    public PickupType type;
    public float durationInseconds;

}
