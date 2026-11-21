using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class CriaturaDuto : MonoBehaviour
{
    public int limite;
    public int difficult;
    [SerializeField] public float _timer;
    public float cooldown;
    public int numeroGuardado;
    public bool eyes = false;
    public float timerDeaft;
    public bool death = false;
    public bool desative = false;
    public bool desative2 = false;
    public bool taAqui = false;
    public AudioSource aS;
    public CameraScript cS;
    public GameObject gOP;
    private void Start()
    {
        gOP.SetActive(false);
    }
    private void Update()
    {
      
        _timer += Time.deltaTime;
        if(_timer >= cooldown && desative2 == false)
        {
            RolarNumero();
            _timer = 0;
        }

        if (eyes == true && _timer >= timerDeaft && death == false && desative == false)
        {
            death = true;
            Debug.LogErrorFormat("Morte");
        }

        if (cS.posicaoX == 40 && eyes == true && taAqui == true)
        {
            aS.Play();  
            taAqui = false; 
        }
        if (cS.posicaoX != 40) { aS.Stop(); taAqui = true;}
    }

    public void RolarNumero()
    {
        numeroGuardado = Random.Range(0, 100);
        cooldown = Random.Range(7, 9);
        if (numeroGuardado <= difficult)
        {
            limite++;
            if(limite >= 2)
            {

                taAqui = true;
                limite = 0;
                gOP.SetActive(true);
                eyes = true;
                desative2 = true;
            }
        }

    }
}
