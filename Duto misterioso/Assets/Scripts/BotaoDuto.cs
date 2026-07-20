using UnityEngine;

public class BotaoDuto : MonoBehaviour
{
    [SerializeField] CriaturaDuto cD;
    [SerializeField] private float _timer;
    public float timerQuebrar;
    public float timerConsertar;
    public float criaturaSair;
    private SpriteRenderer sR;
    public Sprite[] sprites;
    public bool fechado = false;
    public bool quebrado = false;


    private void OnMouseEnter()
    {
        if (fechado == false && quebrado == false)
        {
            sR.sprite = sprites[1];
            fechado = true;
            cD.eyes = false;
        }
        
    }

    private void OnMouseExit() 
    {
        sR.sprite = sprites[0];
        fechado = false;
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (cD.eyes == true && fechado == false)
        {
            sR.sprite = sprites[2];
        }
        else if (fechado == true && _timer >= criaturaSair && cD.eyes == true)
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
                sR.sprite = sprites[0];
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
        sR = GetComponent<SpriteRenderer>();
    }
}
