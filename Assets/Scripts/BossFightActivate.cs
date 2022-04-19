using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightActivate : MonoBehaviour
{
    public void ChangeWall() 
    {
        var wall = this.GetComponent<BoxCollider>();
        if(null != wall)
        {
            wall.isTrigger = false;
        }
    }

}
