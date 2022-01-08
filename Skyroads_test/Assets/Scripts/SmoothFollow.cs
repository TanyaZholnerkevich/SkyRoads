using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float _distance = 8.0f;
    public float _height = 5.0f;
    public float _heightDamping = 2.0f;
    public float _rotationDamping = 3.0f;
    private int _zoom = 30;
    private int _normal = 60;
    private int _smoth = 5;

    public Transform _target;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        // Early out if we don't have a target
        if (!_target)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoom, Time.deltaTime * _smoth);
            _height = 2.5f;
        }
        else
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _normal, Time.deltaTime * _smoth);
            _height = 3.0f;
        }

        // Calculate the current rotation angles
        float _wantedRotationAngle = _target.eulerAngles.y;
        float _wantedHeight = _target.position.y + _height;

        float _currentRotationAngle = transform.eulerAngles.y;
        float _currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        _currentRotationAngle = Mathf.LerpAngle(_currentRotationAngle, _wantedRotationAngle, _rotationDamping * Time.deltaTime);

        // Damp the height
        _currentHeight = Mathf.Lerp(_currentHeight, _wantedHeight, _heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, _currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        var _pos = transform.position;
        _pos = _target.position - currentRotation * Vector3.forward * _distance;
        _pos.y = _currentHeight;
        transform.position = _pos;

        // Always look at the target
        transform.LookAt(_target);
    }

}