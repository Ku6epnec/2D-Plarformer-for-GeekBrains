using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private SliderJoint2D _sliderJoint;
    private JointMotor2D _motor;
    private float _motorSpeedLeft = 2f;
    private float _motorSpeedRight = -2f;


    private void Start()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();
    }

    private void Update()
    {
        if (transform.localPosition.x < 17f)
        {
            _motor = _sliderJoint.motor;
            _motor.motorSpeed = _motorSpeedRight;
            _sliderJoint.motor = _motor;
        }

        if (transform.localPosition.x > 30f)
        {
            _motor = _sliderJoint.motor;
            _motor.motorSpeed = _motorSpeedLeft;
            _sliderJoint.motor = _motor;
        }
    }
}
