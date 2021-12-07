using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFPS : MonoBehaviour
{
    public TextMeshProUGUI Fps;
    
    // FPS updates every second
    private float pollingTime = 1f;

    private float time;
    private int frameCount;

    void Update()
    { 
        time += Time.deltaTime;
        frameCount++;

        if(time >= pollingTime) {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            
            // Convert frame rate to readable string
            Fps.text = "FPS: " + frameRate.ToString();

            // Reset
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
