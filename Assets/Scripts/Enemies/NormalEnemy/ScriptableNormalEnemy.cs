using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyParams", menuName = "ScriptableObjects/ScriptableNormalEnemy", order = 3)]
public class ScriptableNormalEnemy : ScriptableObject
{
    // Character properties
    public float charSpeed;
    public float charSpeedRotation;
    public float timeToAttack;
    public float enemyLife;
    // Bullet GameObject
    public float bulletSpeed;
}
