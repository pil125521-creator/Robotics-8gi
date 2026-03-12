using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// 스페이스 버튼을 누르면, 누른시간에 따라 공에게 힘을 위쪽 방향으로 준다.
/// 좌우 방향키를 누르면 핸들이 일정 각도와 시간동안 동작하고 되돌아온다.
/// 속성: 공
/// </summary>
public class Pinball : MonoBehaviour
{
    public int totalScore;
    public Rigidbody ball;
    public float ballPower;
    public Transform leftHandle;
    public Transform rightHandle;
    public float handleDuration;
    public float handleStartAngle;
    public float handleEndAngle;
    public bool isLeftHandleMoving = false;
    public bool isRightHandleMoving = false;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 스페이스 버튼을 누르면, 누른시간에 따라 공에게 힘을 위쪽 방향으로 준다.
        if(Input.GetKey(KeyCode.Space))
        {
            time += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // 공 발사
            ball.AddForce(transform.up * ballPower * time, ForceMode.Impulse);

            time = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(RotateHandle(leftHandle, -handleStartAngle, -handleEndAngle, true));
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StartCoroutine(RotateHandle(leftHandle, -handleEndAngle, -handleStartAngle, false));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(RotateHandle(rightHandle, handleStartAngle, handleEndAngle, true));
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StartCoroutine(RotateHandle(rightHandle, handleEndAngle, handleStartAngle, false));
        }
    }

    IEnumerator RotateHandle(Transform handle, float startAngle, float endAngle, bool isForward)
    {
        Quaternion startQ = Quaternion.AngleAxis(startAngle, handle.forward);
        Quaternion endQ = Quaternion.AngleAxis(endAngle, handle.forward);

        float time = 0;

        while(true)
        {
            time += Time.deltaTime;

            if(time > handleDuration)
            {
                handle.rotation = endQ;

                if(isForward)
                    CheckMoving(handle, false);

                break;
            }

            if(isForward)
               CheckMoving(handle, true);

            handle.rotation = Quaternion.Slerp(startQ, endQ, time/handleDuration);

            yield return null;
        }
    }

    private void CheckMoving(Transform handle, bool isMoving)
    {
        if(handle.name.Contains("Left"))
        {
            isLeftHandleMoving = isMoving;
        }
        else if(handle.name.Contains("Right"))
        {
            isRightHandleMoving= isMoving;
        }
    }
}
