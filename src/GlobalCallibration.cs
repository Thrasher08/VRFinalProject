using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Global Calibration Object")]
public class GlobalCallibration : ScriptableObject
{
    public List<Vector3> callibrationPos;
    public List<Vector3> callibrationPosRight;
}