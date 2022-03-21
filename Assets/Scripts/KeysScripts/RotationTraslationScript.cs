using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTraslationScript : MonoBehaviour
{
    [SerializeField] protected ScriptableKey keyData;
    [SerializeField] protected GameObject keyPrefab;
    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    protected void RotateObject()
    {
        keyPrefab.transform.Rotate(new Vector3(1f, 0f, 0f), keyData.angleRotation);
    }
}
