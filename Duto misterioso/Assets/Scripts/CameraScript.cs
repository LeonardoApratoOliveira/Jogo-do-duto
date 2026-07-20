using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public float speed;
    public float maxX;
    public float minX;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float newX = transform.position.x + (moveInput * speed * Time.deltaTime);
        float clampedX = Mathf.Clamp(newX, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}

