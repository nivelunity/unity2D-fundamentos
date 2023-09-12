using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color nocheColor;


    [SerializeField][Range(4,128)] private int duracionDia;
    [SerializeField][Range(4, 24)] private int dias;

    private Color diaColor;

    void Start()
    {
        diaColor = camara.backgroundColor;
        StartCoroutine(CambiarColor(duracionDia));
    }

    IEnumerator CambiarColor(float tiempo)
    {
        for (int i = 0; i < duracionDia; i++)
        {
            yield return new WaitForSeconds(tiempo);
            InvertirColor();
        }
    }

    private void InvertirColor()
    {
        camara.backgroundColor = camara.backgroundColor == diaColor ?
                                    camara.backgroundColor = nocheColor :
                                    camara.backgroundColor = diaColor;
    }
}
