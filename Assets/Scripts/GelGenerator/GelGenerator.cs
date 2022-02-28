using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelGenerator : MonoBehaviour
{
    [SerializeField] GameObject gelBall;
    [SerializeField] float timeToGenerateBall = 1f;
    [SerializeField] float forceAdded = 30f;
    private float auxTimeToGenBall;

    // Start is called before the first frame update
    void Start()
    {
        auxTimeToGenBall = timeToGenerateBall;
    }

    // Update is called once per frame
    void Update()
    {
        if(auxTimeToGenBall <= 0f)
        {
            GenerateGellBall();
            auxTimeToGenBall = timeToGenerateBall;
        }
        else
        {
            auxTimeToGenBall -= Time.deltaTime;
        }
    }

    private void GenerateGellBall()
    {
       var instBullet = Instantiate(gelBall, transform);
       var force = transform.forward * forceAdded;
       instBullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.Acceleration);
    }


}
