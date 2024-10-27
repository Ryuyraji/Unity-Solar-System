using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRevolve : MonoBehaviour
{
    [SerializeField]
    GameObject fixedStar;
    [SerializeField]
    float revolutionSpeed = 0.5f;        // 공전속도
    [SerializeField]
    float majorAxisRound = 10.0f;       // 장축 반지름 (x축)
    [SerializeField]
    float minorAxisRound = 9.0f;        // 단축 반지름 (z축)
    float angle = 0.0f;                 // 현재 각도
    
    void Start()
    {
        // 중심 오브젝트 (항성) 지정 -> 태양계 : 태양
        fixedStar = GameObject.Find("Sun");
    }

    void Update()
    {
        //// 중심 오브젝트 기준 회전 (원 궤도)
        //transform.RotateAround(fixedStar.transform.position, Vector3.up, revolutionSpeed * Time.deltaTime);

        // 각도 변환
        angle += revolutionSpeed * Time.deltaTime;

        // x, z좌표 타원 방정식 계산
        float x = majorAxisRound * Mathf.Cos(angle);
        float z = minorAxisRound * Mathf.Sin(angle);

        // 타원 궤도 위치로 이동
        transform.position = new Vector3(x, 0, z) + fixedStar.transform.position;

        // 오일러 각도 회전으로 타원 궤도 설정
        Vector3 currnetDirection = fixedStar.transform.position - transform.position;       // 항성 중심 회전
        transform.eulerAngles = new Vector3(0, Mathf.Atan2(currnetDirection.x, currnetDirection.z) * Mathf.Rad2Deg, 0);
    }
}