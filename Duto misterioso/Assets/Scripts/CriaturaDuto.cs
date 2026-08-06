using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class CriaturaDuto : MonoBehaviour
{
    [SerializeField] public List<int> numerosAleatorios = new List<int>();
    public int difficult;
    [SerializeField] private float _timer;
    public float cooldown;
    public int? numeroGuardado;
    public bool eyes = false;
    public float timerDeaft;
    public bool death = false;
    public bool desative = false;
    public bool taAqui = false;
    public AudioSource aS;
    public CameraScript cS;
    public BotaoDuto bD;
    private void Start()
    {
        for (int i = 0; i <= difficult; i++)
        {
            numerosAleatorios.Add(i);
        }
        aS.Stop();
    }
    private void Update()
    {
      
        _timer += Time.deltaTime;
        if (_timer >= cooldown && eyes == false && desative == false)
        {
            _timer = 0;
            RolarNumero();
        }
        if(desative == true)
        {
            numeroGuardado = 0;
        }

        if (numeroGuardado == difficult && eyes == false && desative == false )
        {
            numerosAleatorios.Clear();
            for (int i = 0; i <= difficult; i++)
            {
                numerosAleatorios.Add(i);
            }
            Debug.LogWarning("ta aqui");
            taAqui = true;
            _timer = 0;
            eyes = true;
        }
        if (eyes == true && _timer >= timerDeaft && death == false)
        {
            death = true;
            Debug.LogErrorFormat("Morte");
        }

        if (cS.posicaoX == 40 && eyes == true && taAqui == true)
        {
            aS.Play();  
            taAqui = false; 
        }
        if (cS.posicaoX != 40) { aS.Stop(); taAqui = true; }
        
    }

    public void RolarNumero()
    {
        int indiceAleatorio = Random.Range(0, numerosAleatorios.Count);
        int rolarNumero = numerosAleatorios[indiceAleatorio];
        numerosAleatorios.RemoveAt(indiceAleatorio);
        numeroGuardado = rolarNumero;
        Debug.Log(numeroGuardado);
    }
}
