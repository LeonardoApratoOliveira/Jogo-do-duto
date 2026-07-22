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
    public float timerAnimation;

    private void OnMouseDown()
    {
        if (fechado == false && quebrado == false && timerAnimation >= 0.10f)
        {
            fechado = true;
            cD.eyes = false;
        }

    }

    private void OnMouseUp() 
    {
        animator.Play("DutoAbrindo");
        timerAnimation = 0;
        fechado = false;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        timerAnimation += Time.deltaTime;

        if (timerAnimation >= 0.10f && fechado == true)
        {
            animator.Play("DutoFechando");
        }

        if (fechado == true && _timer >= criaturaSair && cD.eyes == true)
        {
            cD.eyes = false;
            _timer = 0;
            cD.numeroGuardado = null;
        }
        else if (_timer < criaturaSair && cD.eyes == true && fechado == false) { _timer = 0; }

        
        if (fechado == true)
        {
            if (_timer >= timerQuebrar)
            {
                animator.Play("DutoAbrindo");
                quebrado = true;
                fechado = false;
                _timer = 0;
            }
        }
        else if (fechado == false && quebrado == false)
        {
            _timer = 0;
        }
        if(quebrado == true && _timer >= timerConsertar)
        {
            quebrado = false;
        }
    }
    private void Start()
    {
        timerAnimation = 0.10f;
        animator.Play("IdleAberto");
        animator = GetComponent<Animator>();
    }
}
