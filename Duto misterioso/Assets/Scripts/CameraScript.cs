using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public float speed;
    public float maxX;
    public float minX;
    [SerializeField] private CanvasCamera cC;
    [SerializeField] public float _timer;

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

        _timer += Time.deltaTime;

        if (_timer >= cC.difficult)
        {
            cC.pontos--;
            _timer = 0;
        }
        if (cC.pontos >= 10)
        {
            cC.pontos = 10;
        }
        if (cC.pontos  <= 0)
        {
            cC.death = true;
        }
    }
    private void Start()
    {
        cC.pontos = cC.pontosIniciais;
    }
}

