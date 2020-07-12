using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public AnimationCurve curve;
    public float lerpTime = 1f;
    private float currentLerpTime;
    public Transform PointA;
    public Transform PointB;
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float t = curve.Evaluate(currentLerpTime);
            transform.localPosition = Vector3.Lerp(PointA.localPosition, PointB.localPosition, t);
        }
        else
        {
            transform.localPosition = PointA.localPosition;
        }
    }
}
