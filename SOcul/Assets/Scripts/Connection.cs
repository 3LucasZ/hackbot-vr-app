using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using NativeWebSocket;

public class Connection : MonoBehaviour
{
    WebSocket websocket;
    //controllable assets
    RawImage imageObject;
    Texture2D tex;

    async void Start()
    {
        imageObject = GameObject.Find("DynamicImage").GetComponent<RawImage>();
        tex = new Texture2D(1, 1);
        websocket = new WebSocket("ws://192.168.1.144:5000");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open");
        };
        websocket.OnError += (e) =>
        {
            Debug.Log("Error: " + e);
        };
        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed");
        };
        websocket.OnMessage += (bytes) =>
        {
            var data = Convert.FromBase64String(System.Text.Encoding.UTF8.GetString(bytes));
            tex.LoadImage(data);
            Debug.Log(data);
            imageObject.texture = tex;
        };
        //keep sending messages at every 1s
        InvokeRepeating("SendWebSocketMessage", 0.0f, 1.0f);
        await websocket.Connect();
    }
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();
#endif
    }
    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            await websocket.SendText("HELLO SERVER");
        }
    }
    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }
}