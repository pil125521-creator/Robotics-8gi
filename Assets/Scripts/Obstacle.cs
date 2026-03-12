using UnityEngine;

/// <summary>
/// Ball에 충돌하면 PinballManager의 점수를 올린다.
/// </summary>
public class Obstacle : MonoBehaviour
{
    public Pinball pinballManager;
    public int myPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            pinballManager.totalScore += myPoint;
            print(pinballManager.totalScore);
        }
    }

}
