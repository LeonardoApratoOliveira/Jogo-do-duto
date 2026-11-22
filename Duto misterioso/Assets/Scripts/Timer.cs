using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    [SerializeField] public float timer;
    [SerializeField] private float _timerFake;
    [SerializeField] private TextMeshProUGUI textoAudacia;
    public int audacia;
    public float passarTempo;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Animator animator;
    public GameObject victoryWin;
    public CriaturaDuto cD;
    public CriaturaPorta criaturaPorta;
    public CanvasCamera cC;
    public CameraScript cS;
    public AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI textoRank;
    [SerializeField] JumpscareActive jA;
    private bool quatroMinutos;
    bool doisMinutos = false;
    void UpdateTimerUi()
    {
        int minutos = Mathf.FloorToInt(timer / 60);
        int segundos = Mathf.FloorToInt(timer % 60);
        texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
    void UpdateAudaciaUI()
    {
        textoAudacia.text = $"VOCE OBTEVE {audacia} PONTOS DE AUDACIA!!!";
    }
    [SerializeField] GameObject gOV;
    void Update()
    {
        _timerFake += Time.deltaTime;
        if (_timerFake > passarTempo)
        {
            timer++;
            _timerFake = 0;
            if (passarTempo == 0.5f)
            {
                audacia++;
            }
        }

        if (passarTempo >= 1)
        {
            passarTempo = 1;
        }
        UpdateTimerUi();

        
        if (timer >= 360 && jA.derrotado == false)
        {
            Destroy(gOV);
            if (cD.difficult <= 65 && cC.difficult <= 65 && criaturaPorta.difficult <= 65)
            {
                audacia = audacia * 2;
            }
            else if (cD.difficult > 65 && cC.difficult > 65 && criaturaPorta.difficult > 65)
            {
                audacia = audacia * 3;
            }
            
            if (audacia >= 165)
            {
                textoRank.text = "RANK S";
                textoRank.color = Color.gold;
            }
            else if (audacia >= 115)
            {
                textoRank.text = "RANK A";
                textoRank.color = Color.darkCyan;
            }
            else if (audacia >= 95)
            {
                textoRank.text = "RANK B";
                textoRank.color = Color.lightSkyBlue;
            }
            else if (audacia >= 55)
            {
                textoRank.text = "RANK C";
                textoRank.color = Color.midnightBlue;
            }
            else { textoRank.text = "RANK F"; textoRank.color = Color.darkRed; }

            cD.gOP.SetActive(false);
            cD.timerDeaft = 1000;
            cD.difficult = 0;
            cD.aS.Stop();
            UpdateAudaciaUI();
            cC.difficult = 0;
            cS.cooldown = 1000;
            cC.pontos = 10;
            criaturaPorta.desative = true;
            criaturaPorta.difficult = 0;
            cD.desative = true;
            victoryWin.SetActive(true);
            cS.cameraTravada = true;
            audioSource.Stop();
            Destroy(gameObject);
        }
        
        
        if (timer >= 120 && !doisMinutos)
        {
            doisMinutos=true;
            Tempo();
        }
        if(timer >= 240 && quatroMinutos == false)
        {
            quatroMinutos = true;
            Tempo();
        }
    }

    private void Tempo()
    {
        cD.difficult += 8;
        cC.difficult += 8;
        criaturaPorta.difficult += 9;

        cC.pontos = cC.pontos - 1;
        cD.timerDeaft = cD.timerDeaft - 2;
    }

    private void OnMouseOver()
    {
        passarTempo = 0.5f;
        animator.Play("PortaSaida");
        
    }
    [SerializeField] private AudioSource somPorta;
    private void OnMouseEnter()
    {
        somPorta.Play();
    }
    private void OnMouseExit()
    {

        passarTempo = 1;
        animator.Play("PortaIdle");
        
    }

    private void Start()
    {
        somPorta.Pause();
        UpdateAudaciaUI();
        animator.Play("PortaIdle");
        victoryWin.SetActive(false);
        quatroMinutos = false;
    }
    
}
