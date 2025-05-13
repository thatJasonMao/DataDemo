using UnityEngine;

[RequireComponent(typeof(Transform))]
public class XZCircleMotion : MonoBehaviour
{
    public static Vector3 centerPoint = new Vector3(0, 0.5f, 0);

    private float radius = 0f;

    private float angularSpeed = 0f;

    private float _currentAngle;

    private Transform _transform;

    private void Awake()
    {
        AI_Reference.Instance.RegisterNPC(this.gameObject);
        
        radius = Random.Range(1f, 10f);

        angularSpeed = Random.Range(360f, 720f);

        _transform = transform;
        _transform.position = new Vector3(centerPoint.x + radius, centerPoint.y, centerPoint.z);
        _currentAngle = 0f;
    }

    private void Update()
    {
        _currentAngle += angularSpeed * Time.deltaTime;
        _currentAngle %= 360f;

        float radians = _currentAngle * Mathf.Deg2Rad;

        float xPos = centerPoint.x + Mathf.Cos(radians) * radius;
        float zPos = centerPoint.z + Mathf.Sin(radians) * radius;

        _transform.position = new Vector3(xPos, centerPoint.y, zPos);
    }
}
