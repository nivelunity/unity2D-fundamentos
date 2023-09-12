using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color nocheColor;
    [SerializeField] private float segundos;

    private Color diaColor;

    void Start()
    {
        diaColor = camara.backgroundColor;
        InvokeRepeating("CambiarColor", segundos, segundos);
    }

    void CambiarColor()
    {
        if(camara.backgroundColor == diaColor)
        {
            camara.backgroundColor = nocheColor;
        }
        else
        {
            camara.backgroundColor = diaColor;
        }
    }
}
