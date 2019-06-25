using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCalibration : MonoBehaviour
{
    public GameObject puzzle;
    public GlobalCallibration storePos;
    // Start is called before the first frame update
    void Start()
    {
        leftPositionCheck();
        //rightPositionCheck();
    }

    public void leftPositionCheck()
    {
        if (storePos.callibrationPos[0].x > -0.35)
        {
            puzzle.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (storePos.callibrationPos[0].x < -0.35 && storePos.callibrationPos[0].x > -0.48)
        {
            puzzle.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }
        else
        {
            puzzle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (storePos.callibrationPos[2].z < 0.5)
        {
            puzzle.transform.position -= new Vector3(0, 0, 0.7f);
        }
        else if (storePos.callibrationPos[2].z > 0.5 && storePos.callibrationPos[2].z < 0.9)
        {
            puzzle.transform.position -= new Vector3(0, 0, 0.5f);
        }
        else
        {
            puzzle.transform.position = new Vector3(0, 1.243f, 0.433f);
        }
    }

    /*public void rightPositionCheck()
    {
        if (storePos.callibrationPos[0].x < 0.7)
        {
            puzzle.transform.localScale -= new Vector3(0.12f, 0.1f, 0.1f);
        }
        else if (storePos.callibrationPos[0].x > 0.7 && storePos.callibrationPos[0].x < 0.9)
        {
            puzzle.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        }
        else
        {
            puzzle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (storePos.callibrationPos[2].z < 0.5)
        {
            puzzle.transform.position -= new Vector3(0, 0, 0.7f);
        }
        else if (storePos.callibrationPos[2].z > 0.5 && storePos.callibrationPos[2].z < 0.9)
        {
            puzzle.transform.position -= new Vector3(0, 0, 0.5f);
        }
        else
        {
            puzzle.transform.position = new Vector3(0, 1.243f, 0.433f);
        }
    }*/

    // Update is called once per frame
    void Update()
    {

    }
}
