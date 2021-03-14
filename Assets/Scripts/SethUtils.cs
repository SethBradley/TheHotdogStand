using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SethUtils
{

public class MathTools
{
    public static float RandomNumberGeneration(float startRange, float endRange)
    {
        return UnityEngine.Random.Range(startRange, endRange);
    }

    public static int RandomNumberGeneration(int startRange, int endRange)
    {
        return UnityEngine.Random.Range(startRange, endRange);
    }
    
}
    
public class PhysicsTools
{
    public static Vector3 ProperLerpRotation (Vector3 startRotation, Vector3 targetRotation,float lerpRate)
    {

        float xLerp = Mathf.LerpAngle(startRotation.x, targetRotation.x, lerpRate);
        float yLerp = Mathf.LerpAngle(startRotation.y, targetRotation.y, lerpRate);
        float zLerp = Mathf.LerpAngle(startRotation.z, targetRotation.z, lerpRate);
        Vector3 Lerped = new Vector3(xLerp, yLerp, zLerp);

        return Lerped;
    }
}
}