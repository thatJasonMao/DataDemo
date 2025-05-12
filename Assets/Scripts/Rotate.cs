using UnityEngine;

[RequireComponent(typeof(Transform))]
public class XZCircleMotion : MonoBehaviour
{
    public static Vector3 centerPoint = new Vector3(0, 0.5f, 0);

    private float radius = 5f;

    private float angularSpeed = 360f;

    private float _currentAngle;

    private Transform _transform;

    void Start()
    {
        _transform = transform;
        _transform.position = new Vector3(centerPoint.x + radius, centerPoint.y, centerPoint.z);
        _currentAngle = 0f;
    }

    void Update()
    {
        _currentAngle += angularSpeed * Time.deltaTime;
        _currentAngle %= 360f;

        float radians = _currentAngle * Mathf.Deg2Rad;

        float xPos = centerPoint.x + Mathf.Cos(radians) * radius;
        float zPos = centerPoint.z + Mathf.Sin(radians) * radius;

        _transform.position = new Vector3(xPos, centerPoint.y, zPos);
    }
}
