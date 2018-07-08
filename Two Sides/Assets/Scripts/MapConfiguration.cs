using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfiguration : MonoBehaviour {

    public GameObject straight;
    public GameObject left;
    public int leftAmount;
    public GameObject right;
    public int rightAmount;

    private Vector3 map;
    private int straightAmount;

    void Awake()
    {
        straightAmount = Random.Range((leftAmount + rightAmount * 2), (leftAmount + rightAmount * 6));
    }

    public int ReturnStraightAmount()
    {
        return straightAmount;
    }


}
