using UnityEngine;

public class eyes : MonoBehaviour
{
    public enum RotationAxes
    {
        XandY,
        X,
        Y
    }
    public RotationAxes _axes;
    public float _rotationSpeedHor = 5.0f; //�������� �������� �� �����������
    public float _rotationSpeedVer = 5.0f;

    public float maxVert = 45.0f; //������������ ���� �������� �� ���������
    public float minVert = -45.0f;

    private float _rotationX = 0; //���������� ��� ���� �������� �� ���������

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null )
            body.freezeRotation = true;
    }
    private void Update()
    {
        if(_axes == RotationAxes.XandY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer; //�������� ������������ ��� Y
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //������������ ��������

            float delta = Input.GetAxis("Mouse X") * _rotationSpeedHor;
            float _rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, _rotationY,0);
        }
        else if (_axes == RotationAxes.X)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X") * _rotationSpeedHor, 0); //�������� ������������ ��� X � ������� �������
        }
        else if(_axes == RotationAxes.Y)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _rotationSpeedVer; //�������� ������������ ��� Y
            _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert); //������������ ��������
            float _rotationY = transform.localEulerAngles.y; //��������� ���������� ���� �������� ������ ��� Y
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }

}
