using UnityEngine;
using UnityEngine.SceneManagement;
public class GameButton : MonoBehaviour
{
    public GameObject seleçaoDificult;
    public GameObject tutorial;

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Play()
    {
        seleçaoDificult.SetActive(true);
    }

    public void Tutorial()
    {
        tutorial.SetActive(true);
    }

    public void Exit()
    {
        tutorial.SetActive(false);
    }

    public void Dificult1()
    {
        SceneManager.LoadScene("JogoNivel1");
    }
    public void Dificult2()
    {
        SceneManager.LoadScene("JogoNivel2");
    }
    public void Dificult3()
    {
        SceneManager.LoadScene("JogoNivel3");
    }
    public void Start()
    {
        seleçaoDificult.SetActive(false);
        tutorial.SetActive(false);
    }
}
