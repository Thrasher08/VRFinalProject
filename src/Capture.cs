using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Capture : MonoBehaviour
{

    public RenderTexture captureRT;
    Texture2D lastConvertedTexture;

    public void GetRTPixels()
    {
        // Remember currently active render texture
        RenderTexture currentActiveRT = RenderTexture.active;

        // Set the supplied RenderTexture as the active one
        RenderTexture.active = captureRT;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(captureRT.width, captureRT.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        // Restorie previously active render texture
        RenderTexture.active = currentActiveRT;

        lastConvertedTexture = tex;
    }

    public void SaveLastConvertedTexture()
    {
        Texture2D newTexture = new Texture2D(lastConvertedTexture.width, lastConvertedTexture.height, TextureFormat.ARGB32, false);

        newTexture.SetPixels(0, 0, lastConvertedTexture.width, lastConvertedTexture.height, lastConvertedTexture.GetPixels());
        newTexture.Apply();
        byte[] bytes = newTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Captures/" + System.DateTime.Now.ToString("yyyymmddhhmmss") + ".png", bytes);

        Debug.Log("Saved to " + Application.dataPath + "/Captures/" + System.DateTime.Now.ToString("yyyymmddhhmmss") + ".png");
    }

    public static void SaveTexture(Texture2D target, string name)
    {
        Texture2D newTexture = new Texture2D(target.width, target.height, TextureFormat.ARGB32, false);

        newTexture.SetPixels(0, 0, target.width, target.height, target.GetPixels());
        newTexture.Apply();
        byte[] bytes = newTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Captures/" + name + ".png", bytes);

        Debug.Log("Saved to " + Application.dataPath + "/Captures/" + name + ".png");
    }

    

}
