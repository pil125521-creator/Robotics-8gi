using UnityEngine;

/// <summary>
/// PLC의 출력신호(ex. Y20)를 받아 솔레노이드에 신호가 들어온다.
/// 솔레노이드 신호에 따라 실린더 로드가 전진, 후진한다.
/// 속성: 후방LS의 PLC신호, 전방LS의 PLC신호, LS0과 LS1의 MeshRenderer
///       SOL0의 PLC신호, SOL1의 PLC 신호
///       실린더 Rod의 Transform, 앞방향 maxPos, 뒷방향 minPos(이동 축의 최소, 최대값)
///       실린더 이동속도(공압), 리턴스피드(단동 솔레노이드에서만 사용)
///       단동, 복동 열거형
/// </summary>
public class Cylinder : MonoBehaviour
{
    public enum SolenoidType
    {
        단동형,
        복동형
    }

    [Header("PLC 신호들")]
    public bool backSignal_LS;
    public bool frontSignal_LS;
    public bool backSignal_SOL;
    public bool frontSignal_SOL;

    [Header("기타 설정들")]
    public SolenoidType solenoidType = SolenoidType.단동형;
    public Transform rod;
    public float maxPos;
    public float minPos;
    public float speed = 2; // 공압 조절 밸브에 따른 속도
    public float returnSpeed = 3; // 단동 솔레노이드의 복귀 속도
    public MeshRenderer mrBackLS;
    public MeshRenderer mrFrontLS;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
