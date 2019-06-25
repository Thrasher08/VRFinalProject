using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class TextureComparator : MonoBehaviour
{
    public Texture2D[] comparisonTexs;

    Texture2D drawing2D;
    public RenderTexture drawing;
    public RenderTexture comaprisonRender;
    public List<Texture2D> drawingTexture;
    public Texture2D test;

    Color[] ccPix;
    Color[] dPix;
    Color[] testPix;

    [SerializeField]
    bool working = false;
    [SerializeField]
    bool failed = false;
    [SerializeField]
    bool ccPixDone = false;
    [SerializeField]
    bool dPixDone = false;

    [SerializeField]
    int i;
    [SerializeField]
    int nextTex = 0;
    [SerializeField]
    int tolerance = 0;

    //Tolerance Ranges
    int tol25Per = 16384;
    int tol50Per = 32768;
    int tol75Per = 49152;
    int tol100Per = 65536;

    private void Start()
    {

    }

    void Update()
    {
        
    }

    Texture2D RenderToTexture2D(RenderTexture rTex)
    {
        drawing2D = new Texture2D(256, 256, TextureFormat.ARGB32, false);
        RenderTexture.active = rTex;
        drawing2D.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        drawing2D.Apply();
        return drawing2D;
    }

    public void CompareTex(/*Texture2D[]*/ RenderTexture comaprisonRender, /*Texture2D test*/ RenderTexture drawing)
    {
        //ccPix = comparisonTexs[nextTex].GetPixels();
        RenderToTexture2D(comaprisonRender);
        ccPix = duplicateTexture(drawing2D).GetPixels();    //???????????
        ccPixDone = true;

        //testPix = test.GetPixels();
        RenderToTexture2D(drawing);

        dPix = duplicateTexture(drawing2D).GetPixels();

        //dPix = drawing2D.GetPixels();
        dPixDone = true;
        tolerance = 0;

        for (i = 0; i < ccPix.Length; i++)
        {
            if (ccPix[i] != /*testPix[i]*/ dPix[i])
            //if (!ccPix[i].Equals(dPix[i]))
            {
                tolerance++;
                if (tolerance > tol100Per)
                {
                    failed = true;
                    if (working == true)
                    {
                        working = false;
                    }
                    return;
                }

            }
        } if (tolerance < tol100Per)
        {
            working = true;
            nextTex++;
        }
    }

    public void RunComparison()
    {
        CompareTex(comaprisonRender, /*test*/ drawing);
    }

    public void SaveTexToPNG()
    {
        var bytes = drawing2D.EncodeToPNG();
        var bytesss = tol100Per.ToString();

        var dirPath = Application.dataPath + "/../ComparisonTextures/";

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        File.WriteAllBytes(dirPath + "Image-" + timeStamp + ".png", bytes);
    }

    //https://stackoverflow.com/questions/44733841/how-to-make-texture2d-readable-via-script
    Texture2D duplicateTexture(Texture2D source)
    {
        RenderTexture renderTex = RenderTexture.GetTemporary(
                    source.width,
                    source.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(source, renderTex);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = renderTex;
        Texture2D readableText = new Texture2D(source.width, source.height);
        readableText.ReadPixels(new Rect(0, 0, renderTex.width, renderTex.height), 0, 0);
        readableText.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(renderTex);
        return readableText;
    }
}
