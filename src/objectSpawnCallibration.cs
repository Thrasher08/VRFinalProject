using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class objectSpawnCallibration : MonoBehaviour
{
    public GlobalCallibration storePos;
    public GameObject callibrationObj;
    public GameObject continueUI;

    public GameObject[] instructions;

    [SerializeField]
    Vector3 handDistance;
    [SerializeField]
    Quaternion handRotation;

    bool isCallibrated;
    float timer;
    float instructionNum = 0;

    [SerializeField]
    public List<GameObject> calliObjs;
    public List<Vector3> calliPos;

    // Start is called before the first frame update
    void Start()
    {
        calliObjs = new List<GameObject>();
        calliPos = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (isCallibrated == false){
            spawnObject(callibrationObj);
        } else if (timer > 2.0f)
        {
            isCallibrated = false;
            timer = 0;
        }
        ClearCalibration();
        DisplayInstructions();

    }

    public void spawnObject(GameObject callibrationObj)
    {
        handDistance = gameObject.transform.position;
        handRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            isCallibrated = true;
            calliObjs.Add(Instantiate(callibrationObj, handDistance, handRotation));
            calliPos.Add(handDistance);
            instructionNum += 1;

            if (calliObjs.Count > 3)
            {
                Destroy(calliObjs[0]);
                calliObjs.RemoveAt(0);
                calliPos.RemoveAt(0);
            }

        }
        if (calliObjs.Count == 3)
        {
            storePos.callibrationPos = calliPos;
            continueUI.SetActive(true);
        }
        else
        {
            continueUI.SetActive(false);
        }
    }

    public void ClearCalibration()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four) && OVRInput.GetDown(OVRInput.Button.Two)){

            for (int i = 0; i <= calliObjs.Count; i++)
            {
                Destroy(calliObjs[i]);
            }

            calliObjs.Clear();
            calliPos.Clear();
            continueUI.SetActive(false);
            instructionNum = 0;
        }
    }

    public void DisplayInstructions()
    {
        if (instructionNum == 0)
        {
            instructions[0].SetActive(true);
            instructions[1].SetActive(false);
            instructions[2].SetActive(false);
        }

        if (instructionNum == 1)
        {
            instructions[0].SetActive(false);
            instructions[1].SetActive(true);
            instructions[2].SetActive(false);
        }

        if (instructionNum == 2)
        {
            instructions[0].SetActive(false);
            instructions[1].SetActive(false);
            instructions[2].SetActive(true);
        }

        if (instructionNum > 2)
        {
            instructionNum = 0;
        }
    }

}
