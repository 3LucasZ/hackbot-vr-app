using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServoLog : MonoBehaviour
{
    // Start is called before the first frame update
    Text textGameObject;
    void Start()
    {
        textGameObject = gameObject.GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textGameObject.text = "(" + SendServo.pan + ", " + SendServo.tilt + ")";
    }
}
