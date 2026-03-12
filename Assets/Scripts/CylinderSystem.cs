using UnityEngine;

public class CylinderSystem : MonoBehaviour
{
    public Sensor sensor;
    public Transform pusher;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sensor.isDetected)
        {
            // 푸셔 이동...
        }
    }
}
