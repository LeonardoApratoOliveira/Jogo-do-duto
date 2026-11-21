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
            cD.difficult = cN.difficultD * 8;
            CriaPort.difficult = cN.difficultP * 8;
            cam.difficult = cN.difficultC * 8;
            if(cN.taNoNightmare == true)
            {
                cameraScript.nigtmare = true;
            }
            cN.taEmQualCena++;
        }
        
    }


}
