using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

/// <summary>
/// 3초 후에 적을 소환한다.
/// 속성: 스폰딜레이, 적 프리펩
/// </summary>
public class Timer : MonoBehaviour
{
    public float spawnDelay = 3;
    public GameObject enemyPrefab;
    public float time; // 시간 저장용 필드
    public Transform targetA;
    public Transform targetB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy()); // 코루틴 메서드 시작

        StartCoroutine(CoroutineStudy());

        StartCoroutine(FollowTarget(Vector3.right));

        StartCoroutine(MoveSequence());
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;

        //if (time > spawnDelay)
        //{
        //    GameObject go = Instantiate(enemyPrefab);
        //    go.transform.SetParent(transform);    // 부모 설정하기
        //    go.transform.localPosition = Vector3.zero; // 부모의 위치로 초기화

        //    time = 0;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartSequence());
        }
    }

    // 코루틴 메서드: 유니티에서 비동기 기능을 실행하는 메서드
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            yield return null; // 1프레임 기다리기

            print(spawnDelay);

            GameObject go = Instantiate(enemyPrefab);
            go.transform.SetParent(transform);    // 부모 설정하기
            go.transform.localPosition = Vector3.zero; // 부모의 위치로 초기화
        }
    }

    IEnumerator CoroutineStudy()
    {
        yield return new WaitForSeconds(1);

        print("1초 지남");

        yield return new WaitForSeconds(3);

        print("4초 지남");
    }

    IEnumerator FollowTarget(Vector3 targetPos)
    {
        print("모터 1 작동");

        yield return new WaitForSeconds(1);

        print("모터 2 작동");

        yield return new WaitForSeconds(1);

        print("모터 3 작동");

        yield return new WaitForSeconds(1);

        print($"그리퍼 작동 {targetPos}");

        // yield return new WaitUntil
    }

    // 실습1. Space 버튼을 누르면 아래의 시퀀스가 순서대로 실행되는 코루틴 메서드
    // SEQ1. 1초 후 0,0,0에서 물체를 생성
    // SEQ2. 1초 후 2,0,0에서 물체를 생성
    // SEQ3. 1초 후 0,2,0에서 물체를 생성
    // SEQ4. 1초 후 0,0,2에서 물체를 생성
    IEnumerator StartSequence()
    {
        // SEQ1. 1초 후 0,0,0에서 물체를 생성
        yield return new WaitForSeconds(1);
        GameObject go = Instantiate(enemyPrefab, transform);
        go.transform.position = new Vector3(0, 0, 0);

        // SEQ2. 1초 후 2,0,0에서 물체를 생성
        yield return new WaitForSeconds(1);
        go = Instantiate(enemyPrefab, transform);
        go.transform.position = new Vector3(2, 0, 0);

        // SEQ3. 1초 후 0,2,0에서 물체를 생성
        yield return new WaitForSeconds(1);
        go = Instantiate(enemyPrefab, transform);
        go.transform.position = new Vector3(0, 2, 0);

        // SEQ4. 1초 후 0,0,2에서 물체를 생성
        yield return new WaitForSeconds(1);
        go = Instantiate(enemyPrefab, transform);
        go.transform.position = new Vector3(0, 0, 2);
    }

    // 실습2. Coroutine을 사용하여 이동 시퀀스 구성하기
    // 1초 후
    // TargetA로 이동 ->  yield return null; // 1프레임 기다리기
    // 1초 후
    // TargetB로 이동
    // 2초 후
    // TargetA로 이동

    IEnumerator MoveSequence()
    {
        GameObject go = Instantiate(enemyPrefab);

        yield return new WaitForSeconds(1); // 1초 후

        yield return MoveObjectToTarget(go, targetA);
        // StartCoroutine(MoveObjectToTarget(go, targetA));

        yield return new WaitForSeconds(1);

        yield return MoveObjectToTarget(go, targetB);

        yield return new WaitForSeconds(2); // 1초 후

        yield return MoveObjectToTarget(go, targetA);
    }

    IEnumerator MoveObjectToTarget(GameObject go, Transform target)
    {
        // TargetA로 이동
        while (true)
        {
            Vector3 dir = target.position - go.transform.position;
            float distance = dir.magnitude;

            if (distance < 0.1f)
            {
                break;
            }

            go.transform.position += dir.normalized * 2 * Time.deltaTime;

            yield return null; // 프레임 업데이트 대기
        }
    }
}