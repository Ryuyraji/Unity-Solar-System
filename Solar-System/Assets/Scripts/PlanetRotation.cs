using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 15f;    // 자전속도

    void Update()
    {
        // 자전 구현 (반시계 방향 회전 기준)
        transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
    }
}

