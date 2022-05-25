using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GyroscopeButton : MonoBehaviour

{
 Gyroscope gyro;
 StreamWriter streamWriter = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Method");
        gyro = Input.gyro;

        if(SystemInfo.supportsGyroscope)
        {
            gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(streamWriter != null)
        {
            streamWriter.WriteLine(Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z);
        }
    }

    public void handleRecording()
    {
        if(streamWriter == null)
        { // Start the recording and make a csv file 
            Debug.Log(Application.dataPath + "/GryoscopeData.csv");
            streamWriter = new StreamWriter(Application.dataPath + "/GryoscopeData"+Time.time+".csv");
            streamWriter.WriteLine("X, Y, Z");
            Debug.Log("Recording data");
        }

        else

        { // Stop the recording
            streamWriter.Close();
            streamWriter = null;
            Debug.Log("Stopped recording");
        }
    }

}
