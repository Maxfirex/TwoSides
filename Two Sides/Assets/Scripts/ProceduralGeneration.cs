using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour {

    public GameObject straight;
    public GameObject turn;
    public int turnAmount;

    private Vector3 map;
    private int straightAmount;

    private float positionX = 0;
    private float positionZ = 0;
    private int lookPosition = 0;

    private float turnRotation = 0;
    private float straightRotation = 0;

    private enum Look { PlusX, MinusX, PlusZ, MinusZ }

    void Awake()
    {
        InstantiateStraights();
        InstantiateTurns();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void InstantiateStraights()
    {
        straightAmount = Random.Range(1, 10);

        for (int i = 0; i < straightAmount; i++)
        {
            if (lookPosition == (int)Look.PlusX)
            {
                if (i == 0) positionX += 3.5f;
                else positionX += 5;
            }
            if (lookPosition == (int)Look.MinusX)
            {
                if (i == 0) positionX -= 3.5f;
                else positionX -= 5;
            }
                
            if (lookPosition == (int)Look.PlusZ)
            {
                if (i == 0) positionZ += 3.5f;
                else positionZ += 5;
            }
            if (lookPosition == (int)Look.MinusZ)
            {
                if (i == 0) positionZ -= 3.5f;
                else positionZ -= 5;
            }

            Instantiate(straight, new Vector3(positionX, 0, positionZ), Quaternion.Euler(new Vector3(0, straightRotation, 0)));
        }
    }

    void InstantiateTurns()
    {
        for (int i = 0; i < turnAmount; i++)
        {
            if (lookPosition == (int)Look.PlusX)
            {
                positionX += 3.5f;
                
                if (Random.value < 0.5)
                {
                    turnRotation = 90;
                    lookPosition = 3;
                }
                else
                {
                    turnRotation = 180;
                    lookPosition = 2;
                }
                straightRotation = 90;
            }
            else if (lookPosition == (int)Look.MinusX)
            {
                positionX -= 3.5f;

                if (Random.value < 0.5)
                {
                    turnRotation = 0;
                    lookPosition = 3;
                }
                else
                {
                    turnRotation = -90;
                    lookPosition = 2;
                }
                straightRotation = 90;
            }
            else if (lookPosition == (int)Look.PlusZ)
            {
                positionZ += 3.5f;

                if (Random.value < 0.5)
                {
                    turnRotation = 0;
                    lookPosition = 0;
                }
                else
                {
                    turnRotation = 90;
                    lookPosition = 1;
                }
                straightRotation = 0;
            }
            else
            {
                positionZ -= 3.5f;

                if (Random.value < 0.5)
                {
                    turnRotation = -90;
                    lookPosition = 0;
                }
                else
                {
                    turnRotation = 180;
                    lookPosition = 1;
                }
                straightRotation = 0;

            }

            Instantiate(turn, new Vector3(positionX, 0, positionZ), Quaternion.Euler(new Vector3(0, turnRotation, 0)));

            InstantiateStraights();
        }
    }
}
