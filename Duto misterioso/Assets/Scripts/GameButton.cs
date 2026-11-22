using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonsGame;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject challenges;
    [SerializeField] private GameObject difficultSelection;
    [SerializeField] private GameObject back;
    [SerializeField] private GameObject creditos;
    [SerializeField] CustomNight cN;
    [SerializeField] GameObject gO;

    public void Jogo()
    {
        cN.taEmQualCena++;
        StartCoroutine(IrParaJogo());
    }
    public void Play()
    {
        buttonsGame.SetActive(false);
        playButton.SetActive(false);
        challenges.SetActive(true);
        back.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Challenges()
    {
        difficultSelection.SetActive(true);
        back.SetActive(true);
        challenges.SetActive(false);
        playButton.SetActive(true);
    }

    public void Back()
    {
        buttonsGame.SetActive(true);
        challenges.SetActive(false);
        difficultSelection.SetActive(false);
        back.SetActive(false);
        creditos.SetActive(false);
    }
    public void Creditos()
    {
        buttonsGame.SetActive(false);
        back.SetActive(true);
        creditos.SetActive(true);
    }

    
    public void Rolar()
    {
        int ran1 = Random.Range(0, 11);
        int ran2 = Random.Range(0, 11);
        int ran3 = Random.Range(0, 11);
        cN.difficultC = ran1;
        cN.difficultD = ran2;
        cN.difficultP = ran3;

        cN.UIC();
        cN.UID();
        cN.UIP();
    }

    public void Max()
    {
        cN.difficultC = 10;
        cN.difficultD = 10;
        cN.difficultP = 10;

        cN.UIC();
        cN.UID();
        cN.UIP();
    }

    public void Min()
    {
        cN.difficultC = 0;
        cN.difficultD = 0;
        cN.difficultP = 0;

        cN.UIC();
        cN.UID();
        cN.UIP();
    }

    public void Nightmare()
    {
        cN.difficultC = 9; 
        cN.difficultD = 9; 
        cN.difficultP = 9; 
        cN.taEmQualCena++;
        cN.taNoNightmare = true;
        StartCoroutine(IrParaJogo());
    }

    public void Dificil()
    {
        cN.difficultC = 7;
        cN.difficultD = 7;
        cN.difficultP = 7;
        cN.taEmQualCena++;
        StartCoroutine(IrParaJogo());
    }

    public void medio()
    {
        cN.difficultC = 5;
        cN.difficultD = 5;
        cN.difficultP = 5;
        cN.taEmQualCena++;
        StartCoroutine(IrParaJogo());
    }
    public void Normal()
    {
        cN.difficultC = 3;
        cN.difficultD = 3;
        cN.difficultP = 3;
        cN.taEmQualCena++;
        StartCoroutine(IrParaJogo());
    }

    public void facil()
    {
        cN.difficultC = 2;
        cN.difficultD = 2;
        cN.difficultP = 2;
        cN.taEmQualCena++;
        StartCoroutine(IrParaJogo());
    }
    public void Skip()
    {
        SceneManager.LoadScene("Jogo");
    }
    [SerializeField] GameObject fantasma;
    [SerializeField] GameObject canvasParaNaoClicar;
    [SerializeField] GameObject historia;
    IEnumerator IrParaJogo()
    {
        gO.SetActive(true);
        fantasma.SetActive(true);
        canvasParaNaoClicar.SetActive(true);
        yield return new WaitForSeconds(1f);
        historia.SetActive(true);
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene("Jogo");
    }
}
