using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// 실습2. Dog에셋을 사용하여, 강아지 3마리 A -> B -> C -> A 반복...
// 강아지1(A:1초동안 이동, B:2초, C:3초) -> DogRun.cs
// public Transform[] targets
// public float timeA = 1;
// public float timeB = 2;
// public float timeC = 3;

/// <summary>
/// 강아지가 A -> B -> C -> A 이동 반복
/// 속성: ABC의 위치, ABC로 이동하는 시간
/// </summary>
public class DogRun : MonoBehaviour
{
    public List<Transform> targets;
    public float[] durations;
    Vector3 originPos;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartSequence());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartSequence()
    {
        while(true)
        { 
            for(int i = 0; i < targets.Count - 1; i++)
            {
                yield return MoveAtoB(i, i+1);
            }

            yield return MoveAtoB(targets.Count - 1, 0);
        }
    }

    IEnumerator MoveAtoB(int from, int to)
    {
        while (true)
        {
            time += Time.deltaTime;

            if (time > durations[from])
            {
                time = 0;
                break;
            }

            transform.position = Vector3.Lerp(targets[from].position, targets[to].position, time / durations[from]);

            yield return null;
        }
    }
}
