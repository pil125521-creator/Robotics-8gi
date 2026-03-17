using System.Collections;
using UnityEngine;

/// <summary>
/// PLC 신호를 받아 RED, YELLOW, GREEN 램프를 켜고 끈다.
/// 속성: Red, Yellow, Green Signal들, 각 램프들의 매시랜더러
/// </summary>
public class TowerLamp : MonoBehaviour
{
    public bool redLampSignal;
    public bool yellowLampSignal;
    public bool greenLampSignal;

    public MeshRenderer redLampMR;
    public MeshRenderer yellowLampMR;
    public MeshRenderer greenLampMR;

    void Start()
    {
        TurnOffAllLamps();

        StartCoroutine(TurnRedOnBySignal());
        StartCoroutine(TurnYellowOnBySignal());
        StartCoroutine(TurnGreenOnBySignal());
    }

    void TurnOffAllLamps()
    {
        redLampMR.material.color = new Color(0, 0, 0, 0.7f);
        yellowLampMR.material.color = new Color(0, 0, 0, 0.7f);
        greenLampMR.material.color = new Color(0, 0, 0, 0.7f);
    }

    IEnumerator TurnRedOnBySignal()
    {
        while (true)
        {
            yield return new WaitUntil(() => redLampSignal);

            redLampMR.material.color = new Color(1, 0, 0, 0.7f);

            yield return new WaitUntil(() => !redLampSignal);

            redLampMR.material.color = new Color(0, 0, 0, 0.7f);
        }
    }

    IEnumerator TurnYellowOnBySignal()
    {
        while (true)
        {
            yield return new WaitUntil(() => yellowLampSignal);

            yellowLampMR.material.color = new Color(1, 1, 0, 0.7f);

            yield return new WaitUntil(() => !yellowLampSignal);

            yellowLampMR.material.color = new Color(0, 0, 0, 0.7f);
        }
    }

    IEnumerator TurnGreenOnBySignal()
    {
        while (true)
        {
            yield return new WaitUntil(() => greenLampSignal);

            greenLampMR.material.color = new Color(0, 1, 0, 0.7f);

            yield return new WaitUntil(() => !greenLampSignal);

            greenLampMR.material.color = new Color(0, 0, 0, 0.7f);
        }
    }
}
