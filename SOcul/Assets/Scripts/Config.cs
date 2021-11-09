using UnityEngine;
public class Config : MonoBehaviour
{
  //note: const are ALWAYS static
  //oculus on dubhub
  //public static const String OPERATOR_IP = "192.168.1.178";
  //oculus on raspi-ap
  //192.168.50.140
  //mac on raspi-ap
  //192.168.50.149
  //mac on dubhub
  //192.168.1.144
  public const string OPERATOR_IP = "192.168.50.140";
  public const int OPERATOR_CAMERA_PORT = 5001;

  public const string BOT_IP = "192.168.50.1";
  public const int BOT_SERVO_PORT = 5001;
  public const int BOT_MOTOR_PORT = 5002;
  public const int BOT_CAMERA_PORT = 5003;
  public const int BOT_PING_PORT = 10000;
}
