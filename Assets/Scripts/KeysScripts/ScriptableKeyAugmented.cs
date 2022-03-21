using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyParams", menuName = "ScriptableObjects/ScriptableKeyAugmented", order = 2)]
public class ScriptableKeyAugmented : ScriptableObject
{
    // Configuracion de movimiento.
    public float travelDistance;
    public float travelSpeed;
}
