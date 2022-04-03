using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgEnemy", menuName = "ScriptableObjects/ScriptableUpgEnemy", order = 4)]
public class ScriptableUpgEnemy : ScriptableObject
{
    [SerializeField] public float timeToAttack;
    [SerializeField] public GameObject bullet;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public float enemyLife = 200f;
}
