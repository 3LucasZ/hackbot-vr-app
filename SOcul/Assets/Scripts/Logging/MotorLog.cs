using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MotorLog : MonoBehaviour
{
    Text textGameObject;
    // Start is called before the first frame update
    void Start()
    {
        textGameObject = gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textGameObject.text = "(" + SendMotor.motors.x + ", " + SendMotor.motors.y + ")";
    }
}