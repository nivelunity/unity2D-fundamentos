using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour
{
    public void CargarSiguienteEscena()
    {
        ApplicationManager.Instance.GoToNextScene();
    }
}
