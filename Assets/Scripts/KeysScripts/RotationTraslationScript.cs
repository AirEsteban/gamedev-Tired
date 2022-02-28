using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTraslationScript : MonoBehaviour
{
    [SerializeField] GameObject keyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateAndTranslate();
    }

    private void RotateAndTranslate()
    {
        keyPrefab.transform.position.y += 10f;
    }
}
