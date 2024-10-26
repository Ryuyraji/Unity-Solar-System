using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolve : MonoBehaviour
{
    [SerializeField]
    GameObject Sun;
    [SerializeField]
    float revolutionSpeed = 10f;    // 공전속도

    void Start()
    {
        Sun = GameObject.Find("Sun");
    }

    void Update()
    {
        transform.RotateAround(Sun.transform.position, Vector3.up, revolutionSpeed * Time.deltaTime);
    }
}
