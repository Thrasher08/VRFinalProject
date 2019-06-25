using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStartEnd : MonoBehaviour
{
    public PuzzleTimer timer;
    public bool start;
    public bool end;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (start == true)
            {
                timer.StartTimer();
            } else if (end == true)
            {
                timer.StopTimer();
            }
        }
    }

}
