using UnityEngine;

/// <summary>
/// Lerp와 Slerp를 회전을 통해 비교
/// 속성: Lerp바늘, Slerp바늘
/// </summary>
public class LerpSlerp : MonoBehaviour
{
    public Transform lerp바늘;
    Quaternion startQ, endQ;
    public float startAngle = 0, endAngle = 90;

    public Transform Slerp바늘;
    Quaternion startQSlerp, endQSlerp;
    public float startAngleSlerp = 0, endAngleSlerp = 90;

    public float duration = 3;
    float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startQ = Quaternion.AngleAxis(startAngle, lerp바늘.up);
        endQ = Quaternion.AngleAxis(endAngle, lerp바늘.up);

        startQSlerp = Quaternion.AngleAxis(startAngleSlerp, Slerp바늘.up);
        endQSlerp = Quaternion.AngleAxis(endAngleSlerp, Slerp바늘.up);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > duration)
            time = 0;

        Quaternion lerpQ = Quaternion.Lerp(startQ, endQ, time / duration);
        lerp바늘.rotation = lerpQ;

        Quaternion SlerpQ = Quaternion.Slerp(startQSlerp, endQSlerp, time / duration);
        Slerp바늘.rotation = SlerpQ;
    }
}
