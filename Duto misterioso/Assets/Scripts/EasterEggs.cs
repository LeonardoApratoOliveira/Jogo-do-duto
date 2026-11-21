using System;
using UnityEngine;

public class EasterEggs : MonoBehaviour
{

    [SerializeField] private int paraAparecer;
    [SerializeField] private int seuPonto;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject gObject;
    [SerializeField] private float _timer;
    public float cooldown;
    public bool achou = false;

    private void OnMouseDown()
    {
        if (_timer >= cooldown && seuPonto < paraAparecer)
        {
            seuPonto++;
            audioSource.Play();
            _timer = 0;
        }
        else if(seuPonto >= paraAparecer)
        {
            gObject.SetActive(true);
            achou = true;
        }

    }
    public void Start()
    {
        gObject.SetActive (false);
        cooldown = 1;
        _timer = 1;
    }
    public void Update()
    {
        _timer += Time.deltaTime;
    }
    
}
