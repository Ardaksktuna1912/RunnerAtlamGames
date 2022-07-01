using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScooterMove : MonoBehaviour
{

    public float scooterspeed;

    public void Update()
    {

        ScooterControlMove();
    }

    public void ScooterControlMove()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * scooterspeed);
    }
}
