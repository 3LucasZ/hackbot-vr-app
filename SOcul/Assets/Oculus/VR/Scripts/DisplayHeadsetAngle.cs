using UnityEngine;
using UnityEngine.UI;


public class DisplayHeadsetAngle : MonoBehaviour
{
    Text textGameObject;
    GameObject headset;
    void Start()
    {
        textGameObject = gameObject.GetComponent<UnityEngine.UI.Text>();
        headset = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        textGameObject.text = "HELLO WORLD!";
    }

    void Update()
    {
        textGameObject.text = headset.transform.rotation.x.ToString();
    }
}