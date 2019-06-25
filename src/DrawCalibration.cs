using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCalibration : MonoBehaviour
{
    public GameObject trace;
    public GameObject cTrace;
    public GlobalCallibration storePos;
    // Start is called before the first frame update
    void Start()
    {
        if (storePos.callibrationPos[0].x > -0.35)
        {
            trace.transform.localScale = new Vector3(1.25f, 1.25f, 1.0f);
            cTrace.transform.localScale = new Vector3(1.25f, 1.25f, 0.1f);
        }
        else if (storePos.callibrationPos[0].x < -0.35 && storePos.callibrationPos[0].x > -0.48)
        {
            trace.transform.localScale -= new Vector3(0.5f, 0.5f, 1.0f);
            cTrace.transform.localScale -= new Vector3(0.5f, 0.5f, 0.1f);
        }
        else
        {
            trace.transform.localScale = new Vector3(2.2625f, 1.65f, 1.0f);
            cTrace.transform.localScale = new Vector3(2.2625f, 1.65f, 0.1f);
        }

        //2.06, 1.86, 1.73
        if (storePos.callibrationPos[1].y < 1.85)
        {
            trace.transform.position -= new Vector3(0, 1, 0);
            cTrace.transform.position -= new Vector3(0, 1, 0);
        }
        else if (storePos.callibrationPos[1].y > 1.85 && storePos.callibrationPos[1].y < 1.92)
        {
            trace.transform.position -= new Vector3(0, 0.5f, 0);
            cTrace.transform.position -= new Vector3(0, 0.5f, 0);
        }
        else
        {
            trace.transform.position -= new Vector3(0, 0, 0);
            cTrace.transform.position -= new Vector3(0, 0, 0);
        }
    }
}
