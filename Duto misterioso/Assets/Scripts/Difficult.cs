using UnityEngine;

public class Difficult : MonoBehaviour
{
    [SerializeField] private CriaturaDuto cD;
    [SerializeField] private CriaturaPorta CriaPort;
    [SerializeField] private CanvasCamera cam;
    [SerializeField] private CameraScript cameraScript;
    

    private void Start()
    {
        GameObject cNGO = GameObject.FindWithTag("Custom");
        if (cNGO != null)
        {
            CustomNight cN = cNGO.GetComponent<CustomNight>();
            cD.difficult = cN.difficultD * 9;
            CriaPort.difficult = cN.difficultP * 9;
            cam.difficult = cN.difficultC * 9;
            if(cN.taNoNightmare == true)
            {
                cameraScript.nigtmare = true;
            }
            cN.taEmQualCena++;
        }
        
    }


}
