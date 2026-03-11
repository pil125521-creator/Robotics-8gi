using UnityEngine;

/// <summary>
/// 물체A를 현 위치에서 Target까지 2초 동안 이동시킨다.
/// 속성: 물체A, Target, duration
/// </summary>
public class LerpManager : MonoBehaviour
{
    public Transform objA;
    public Transform target;
    public float duration = 3;
    [Range(0, 1)] // Attribute
    public float ratio;
    float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= duration)
            time = 0;

        // 물체A를 현 위치에서 Target까지 2초 동안 이동시킨다.
        Vector3 result = Vector3.Lerp(Vector3.zero, target.position, time/duration);
        objA.position = result;
    }
    
    // 실린더 A가 현위치에서 앞 방향으로 전진, 후진(공압실린더)
    // 실런더 A 전진(2) -> 실린더 B 전진(3)

    // 실습2. Dog에셋을 사용하여, 강아지 3마리 A -> B -> C -> A 반복...
    // 강아지1(A:1초동안 이동, B:2초, C:3초) -> DogRun.cs
    // public Transform[] targets
    // public float timeA = 1;
    // public float timeB = 2;
    // public float timeC = 3;

    // 강아지1 복사...
}
