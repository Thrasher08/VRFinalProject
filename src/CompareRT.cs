using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CompareRT : MonoBehaviour
{

    public RenderTexture rt1;
    public RenderTexture rt2;

    public GlobalCallibration storePos;

    public int differentPixelCount;
    int maxPixels = 65536;
    int canvasPixels = 22592;
    public float accuracy;

    public void Compare()
    {

        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = rt1;
        Texture2D tempTex1 = new Texture2D(rt1.width, rt1.height);
        tempTex1.ReadPixels(new Rect(0, 0, rt1.width, rt1.height), 0, 0);
        tempTex1.Apply();
        RenderTexture.active = previous;

        previous = RenderTexture.active;
        RenderTexture.active = rt2;
        Texture2D tempTex2 = new Texture2D(rt2.width, rt2.height);
        tempTex2.ReadPixels(new Rect(0, 0, rt2.width, rt2.height), 0, 0);
        tempTex2.Apply();
        RenderTexture.active = previous;

        differentPixelCount = 0;

        Color[] firstPix = tempTex1.GetPixels();
        Color[] secondPix = tempTex2.GetPixels();
        if (firstPix.Length != secondPix.Length)
        {
            Debug.LogError("Different Sizes");
            return;
        }
        for (int i = 0; i < firstPix.Length; i++)
        {
            if (firstPix[i] != secondPix[i])
            {
                differentPixelCount++;
            }
        }

        accuracy = (1.0f - ((float) differentPixelCount / ((float) maxPixels - (float) canvasPixels))) * 100.0f;
        WriteToCSV();
        return;

    }

    void WriteToCSV()
    {
        var dirPath = Application.dataPath + "/EvaluationData";
        var path = "/Accuracy.csv";
        string fullPath = dirPath + path;

        if (!Directory.Exists(dirPath)){
            Directory.CreateDirectory(dirPath);
        }
        if (!File.Exists(fullPath))
        {
            File.AppendAllText(fullPath, "Tolerance" + "," + "Accuracy" + "," + "Calibrated X" + "," + "Calibrated Y" + "," + "Calibrated Z" + Environment.NewLine);
        }

        FileInfo fi = new FileInfo(fullPath);
        if (fi.Length <= 0) {

            //File.AppendAllText(fullPath, "Tolerance" + "," + "Accuracy" + "," + "Calibrated X" + "," + "Calibrated Y" + "," + "Calibrated Z" + Environment.NewLine);
            
        }

        string testText = differentPixelCount.ToString() + "," + accuracy.ToString() + "," + storePos.callibrationPos[0].x.ToString() + "," + storePos.callibrationPos[1].y.ToString() + "," + storePos.callibrationPos[2].z.ToString() + Environment.NewLine;
        File.AppendAllText(dirPath + path, testText);
    }

}
