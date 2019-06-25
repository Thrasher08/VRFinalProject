using System.Collections;
using System.Collections.Generic;
using OVRTouchSample;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject paint;
    public GameObject drawing;
    public Transform handTransform;
    Quaternion paintRotation;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            DrawOnObject();
        }
    }

    void DrawOnObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(handTransform.position, handTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Drawable"))
            {
                float x = hit.point.x;
                float y = hit.point.y;
                float z = hit.point.z - 0.01f;
                Vector3 posCorrection = new Vector3(x, y, z);
                GameObject paintPosStore = Instantiate(paint, posCorrection, paintRotation);
                paintPosStore.transform.parent = drawing.transform;
            }
        }
    }

    public void clearPaint()
    {

    }
}
