using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolve : MonoBehaviour
{
    [SerializeField]
    GameObject fixedStar;
    [SerializeField]
    float revolutionSpeed = 10f;    // 공전속도

    void Start()
    {
        // 중심 오브젝트 (항성) 지정 -> 태양계 : 태양
        fixedStar = GameObject.Find("Sun");
    }

    void Update()
    {
        // 중심 오브젝트 기준 회전 (원 궤도)
        transform.RotateAround(fixedStar.transform.position, Vector3.up, revolutionSpeed * Time.deltaTime);
    }
}
