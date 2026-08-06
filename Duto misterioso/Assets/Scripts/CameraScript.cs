using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public bool cameraTravada = false;
    public float tempoParaMexer;
    public float posicaoX = 0;
    [SerializeField] private CanvasCamera cC;
    [SerializeField] public float _timer;
    [SerializeField] private GameObject piscar;
    public AudioSource aS;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && cameraTravada == false && tempoParaMexer >= 0.8f)
        {
            transform.position = new Vector3(posicaoX = posicaoX + 20, 0, -10);
            tempoParaMexer = 0;
            piscar.SetActive(true);
            aS.Play();
        }
        if (posicaoX > 60) { transform.position = new Vector3(posicaoX = 0, 0, -10); }

        if (Input.GetKeyDown(KeyCode.A) && cameraTravada == false && tempoParaMexer >= 0.5f)
        {
            transform.position = new Vector3(posicaoX = posicaoX - 20, 0, -10);
            tempoParaMexer = 0;
            piscar.SetActive(true);
            aS.Play();
        }
        if (posicaoX < 0) { transform.position = new Vector3(posicaoX = 60, 0, -10); }
        if (tempoParaMexer >= 0.8f)
        {
            piscar.SetActive(false);
        }
        

        tempoParaMexer += Time.deltaTime;
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
        piscar.SetActive(false);
    }
}

