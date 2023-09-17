using System;
using UnityEngine;
using TMPro;

public class RadialMenuSector : TextUIElement
{
    public int index { get; private set; }
    private float minAngle, maxAngle;

    public void Init(int index, string text, float minAngle, float maxAngle)
    {
        this.index = index;
        SetText(text);
        this.minAngle = minAngle;
        this.maxAngle = maxAngle;
    }

    public bool IsTargeted(float angle)
    {
        //Debug.Log($"Test {index}: {minAngle} < {angle} < {maxAngle}");
        return angle > minAngle && angle < maxAngle;
    }
}
