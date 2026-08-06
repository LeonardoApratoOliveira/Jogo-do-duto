using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float _timerReal;
    public float passarTempo;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Animator animator;
    public GameObject victoryWin;
    public CriaturaDuto cD;
    public CriaturaPorta criaturaPorta;
    public CanvasCamera cC;
    public CameraScript cS;
    public AudioSource audioSource;
    void UpdateTimerUi()
    {
        int minutos = Mathf.FloorToInt(timer / 60);
        int segundos = Mathf.FloorToInt(timer % 60);
        texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    void Update()
    {
        _timerReal += Time.deltaTime;
        if (_timerReal > passarTempo)
        {
            timer++;
            _timerReal = 0;
        }
        if (passarTempo >= 1)
        {
            passarTempo = 1;
        }
        UpdateTimerUi();

        if (timer >= 360)
        {
            cC.difficult = 1000;
            cC.pontos = 10;
            criaturaPorta.desative = true;
            cD.desative = true;
            victoryWin.SetActive(true);
            cS.cameraTravada = true;
            audioSource.Stop();
        }
    }

    private void OnMouseOver()
    {
        passarTempo = 0.5f;
        animator.Play("PortaSaida");
    }
    private void OnMouseExit()
    {
        passarTempo = 2;
        animator.Play("PortaIdle");
    }

    private void Start()
    {
        animator.Play("PortaIdle");
        victoryWin.SetActive(false);
    }
    
}
