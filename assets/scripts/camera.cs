using UnityEngine;

public class camera : MonoBehaviour
{
    public float DampTime = 0.15f;
    public float Speed = 30.0f;
    public Vector3 Offset;
    public Transform Target;

    // Update is called once per frame
    void FixedUpdate()
    {
        float blend = 1f - Mathf.Pow(DampTime, Time.deltaTime * Speed);
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, blend);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -1.0f);
    }
}
