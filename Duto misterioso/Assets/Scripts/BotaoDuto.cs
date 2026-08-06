using UnityEngine;

public class BotaoDuto : MonoBehaviour
{
    [SerializeField] CriaturaDuto cD;
    [SerializeField] private float _timer;
    public float timerQuebrar;
    public float timerConsertar;
    public float criaturaSair;
    public Animator animator;
    public bool fechado = false;
    public bool quebrado = false;
    public int pontosDuto;
    public int limiteDuto;
    public AudioSource aS;
    public ParticleSystem pS;
    private void OnMouseDown()
    {
        
        if (fechado == false && quebrado == false)
        {
            fechado = true;
            aS.Play();
            pontosDuto++;
        }
    }

    private void OnMouseUp() 
    {
        animator.Play("DutoAbrindo");
        if (fechado == true)
        {
            aS.Play();
        }
        fechado = false;

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        

        if (fechado == true && quebrado == false)
        {
            animator.Play("DutoFechando");
        }

        if (fechado == true && _timer >= criaturaSair && cD.eyes == true)
        {
            cD.aS.Stop();
            cD.eyes = false;
            cD.numeroGuardado = null;
        }
        else if (_timer < criaturaSair && cD.eyes == true && fechado == false) { _timer = 0; }

        
        if (fechado == true)
        {
            
            if (_timer >= timerQuebrar || pontosDuto > limiteDuto)
            {
                aS.Play();
                animator.Play("DutoAbrindo");
                quebrado = true;
                fechado = false;
                _timer = 0;
                pontosDuto = 0;
                pS.Play();
            }
        }
        else if (fechado == false && quebrado == false)
        {
            _timer = 0;
        }
        if(quebrado == true && _timer >= timerConsertar)
        {
            pS.Stop();
            quebrado = false;
        }
        
    }
    private void Start()
    {
        animator.Play("IdleAberto");
        animator = GetComponent<Animator>();
        pS.Stop();
    }
}
