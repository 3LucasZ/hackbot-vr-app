using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchpadLog : MonoBehaviour
{
    RectTransform handle;
    RectTransform pad;
    // Start is called before the first frame update
    void Start()
    {
        handle = GetComponent<RectTransform>();
        pad = GetComponentInParent<RectTransform>();

        handle.anchoredPosition = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        handle.anchoredPosition = new Vector2(SendMotor.joystick.x * pad.rect.width * 1.4f, SendMotor.joystick.y * pad.rect.height * 1.4f);
    }
}


