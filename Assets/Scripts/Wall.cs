using UnityEngine;

/// <summary>
/// 충격을 받으면 알람을 울린다.
/// 충돌확인의 조건: 확인하고자 하는 물체에 RigidBody + Collider
/// </summary>
public class Wall : MonoBehaviour
{
    public int collisionCount = 10;

    // 충돌되는 순간 확인
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name + " 충돌 시작!");

        collisionCount--;

        if(collisionCount <= 0)
            Destroy(gameObject);
    }

    // 충돌중일 때 실행
    private void OnCollisionStay(Collision collision)
    {
        print(collision.transform.name + " 감지중...");
    }

    // 충돌에서 벗어날때
    private void OnCollisionExit(Collision collision)
    {
        print(collision.transform.name + " 충돌 종료!");
    }
}
