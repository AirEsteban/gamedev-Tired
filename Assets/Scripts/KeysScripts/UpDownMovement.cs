using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpDownMovement : RotationTraslationScript
{
    [SerializeField] ScriptableKeyAugmented keyAugmentedData;
    private bool isGoingUp = true;
    private float auxUnitsToMove;

    private void Start()
    {
        auxUnitsToMove = keyAugmentedData.travelDistance;
    }

    // Update is called once per frame
    void Update()
    {
        base.RotateObject();
        //MoveUpAndDown();
    }

    private void MoveUpAndDown()
    {
        if (isGoingUp)
        {
            base.keyPrefab.transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime * keyAugmentedData.travelSpeed;
            auxUnitsToMove--;
            if (auxUnitsToMove < 0f)
            {
                isGoingUp = false;
            }
        }
        else
        {
            base.keyPrefab.transform.position -= new Vector3(0f, 1f, 0f) * Time.deltaTime * keyAugmentedData.travelSpeed;
            auxUnitsToMove--;
            if (auxUnitsToMove < -keyAugmentedData.travelDistance)
            {
                auxUnitsToMove = keyAugmentedData.travelDistance;
                isGoingUp = true;
            }
        }
    }


}
