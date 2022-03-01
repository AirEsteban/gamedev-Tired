using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTraslationScript : MonoBehaviour
{
    [SerializeField] GameObject keyPrefab;
    [SerializeField] float angleRotation = 1f;
    [SerializeField] Transform[] wayPoints;
    private int actIndex;
    // Start is called before the first frame update
    void Start()
    {
        actIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        keyPrefab.transform.Rotate(new Vector3(1f, 0f, 0f), angleRotation);
    }
}
