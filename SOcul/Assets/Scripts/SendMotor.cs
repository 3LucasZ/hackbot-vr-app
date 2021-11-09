using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class SendMotor : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector2 joystick;
    public static Vector2 motors;
    private const int MAX_SPEED = 100;
    //future 0 priority feature
    private const int BINDS = 8;

    UdpClient mySock;
    byte[] sendBytes = new byte[2];
    void Start()
    {
        new Thread(() =>
        {
            mySock = new UdpClient(6001);
            mySock.Connect(Config.BOT_IP, Config.BOT_MOTOR_PORT);
        }).Start();
    }

    // Update is called once per frame
    void Update()
    {
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        float tempX = joystick.x * MAX_SPEED;
        float tempY = joystick.y * MAX_SPEED;

        //convert to polar
        float r = Mathf.Sqrt(tempX * tempX + tempY * tempY);
        float t = Mathf.Atan2(tempY, tempX);

        //rotate by 45 deg
        t -= (Mathf.PI / 4);

        //convert to cartesian and scale
        tempX = r * Mathf.Cos(t) * Mathf.Sqrt(2);
        tempY = r * Mathf.Sin(t) * Mathf.Sqrt(2);

        //set and send
        motors.x = (int) tempX;
        motors.y = (int) tempY;

        sendBytes[0] = (byte)(motors.x + 127);
        sendBytes[1] = (byte)(motors.y + 127);
        mySock.Send(sendBytes, 2);
    }
}
