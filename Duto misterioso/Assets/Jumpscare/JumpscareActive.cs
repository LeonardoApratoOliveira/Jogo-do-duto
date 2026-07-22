using UnityEngine;

public class JumpscareActive : MonoBehaviour
{
    public GameObject jumpscareDuto;
    public GameObject jumpscarePorta;
    public GameObject jumpscareCamera;
    public CriaturaDuto cD;
    public CriaturaPorta criaturaPorta;
    public CanvasCamera cC;


    private void Update()
    {
        if(cD.death == true)
        {
            jumpscareDuto.SetActive(true);
        }
        if (criaturaPorta.death == true)
        {
            jumpscarePorta.SetActive(true);
        }
        if (cC.death == true)
        {
            jumpscareCamera.SetActive(true);
        }

    }

    private void Start()
    {
        jumpscareCamera.SetActive(false);
        jumpscareDuto.SetActive(false);
        jumpscarePorta.SetActive(false);
    }
}
