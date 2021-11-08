using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SendServo : MonoBehaviour
{
    private GameObject headset;

    public static float pan;
    public static float tilt;
    private float PAN_CENTER = 58;
    private float TILT_CENTER = 130;
    
    UdpClient mySock;
    byte[] sendBytes = new byte[2];
    // Start is called before the first frame update
    void Start()
    {
        headset = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        new Thread(() =>
        {
            mySock = new UdpClient(6000);
            mySock.Connect("192.168.1.191", 5000);

        }).Start();
    }

    // Update is called once per frame
    void Update()
    {
        pan = NormalizePan(headset.transform.rotation.y);
        tilt = NormalizeTilt(headset.transform.rotation.x);
        Debug.Log("(" + pan + "," + tilt + ")");
        sendBytes[0] = (byte)(int)pan;
        sendBytes[1] = (byte)(int)tilt;
        mySock.Send(sendBytes, 2);
    }

    float NormalizePan(float angle)
    {
        float newAngle = -1 * angle * 90 / 0.65f;
        newAngle = Mathf.Max(Mathf.Min(newAngle + PAN_CENTER, 116), 0);
        return newAngle;
    }
    float NormalizeTilt(float angle)
    {
        float newAngle = -1 * angle * 90 / 0.65f;
        newAngle = Mathf.Max(Mathf.Min(newAngle + TILT_CENTER, 180), 100);
        return newAngle;
    }
}

