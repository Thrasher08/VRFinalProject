using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadActivites : MonoBehaviour
{
    public void LoadDraw()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadCalibration()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadPuzzle()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
