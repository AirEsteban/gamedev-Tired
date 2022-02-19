using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehavoiur : MonoBehaviour
{
    private float xDir, yDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xDir += transform.position.x;
        yDir += transform.position.y;
        transform.localRotation = Quaternion.Euler(xDir, yDir, 0f);
    }
}
