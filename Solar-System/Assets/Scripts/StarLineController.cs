using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLineController : MonoBehaviour
{
    [SerializeField]
    bool lineSwitch = false;
    [SerializeField]
    GameObject Constellation;

    List<GameObject> starLines = new();     // 별자리 라인, 이름 오브젝트
    List<GameObject> starCetus = new();     // 별자리 이름
    private bool linesInitialized = false;  // starLines 초기화 여부

    void Start()
    {
        Constellation = GameObject.Find("ConstellationViewer");
    }

    void Update()
    {
        // 별자리 라인 오브젝트 최초 한번 비활성화
        if (!linesInitialized && Constellation != null)
        {
            InitializeLines();
        }

        // 버튼 클릭 시 별자리 라인 오브젝트 활성화
        if (lineSwitch && linesInitialized)
        {
            ShowConstellationObj();
        }

        // 버튼 클릭 시 별자리 라인 오브젝트 비활성화
        if (!lineSwitch && linesInitialized)
        {
            HideConstellationObj();
        }
    }


    // 맨 처음 한번 라인 오브젝트들 비활성화 시키기
    void InitializeLines()
    {
        foreach (Transform child in Constellation.transform)
        {
            // 별자리 Line 오브젝트 찾기
            Transform lineObj = child.Find("Lines");
            if (lineObj != null)
            {
                starLines.Add(lineObj.gameObject);
            }
            // 별자리 Name 오브젝트 찾기
            Transform nameObj = child.Find(child.name);
            if (lineObj != null)
            {
                starCetus.Add(nameObj.gameObject);
            }
        }

        // 별자리 관련 오브젝트 비활성화
        HideConstellationObj();

        // starLines 초기화 완료
        linesInitialized = true;
    }

    void ShowConstellationObj()
    {
        foreach (GameObject obj in starLines)
        {
            obj.SetActive(true);
        }

        foreach (GameObject obj in starCetus)
        {
            obj.SetActive(true);
        }
    }

    void HideConstellationObj()
    {
        foreach (GameObject obj in starLines)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in starCetus)
        {
            obj.SetActive(false);
        }
    }
}
