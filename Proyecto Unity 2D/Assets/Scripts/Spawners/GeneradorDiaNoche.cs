using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color nocheColor;


    [SerializeField][Range(1, 128)] private int duracionDia;
    [SerializeField][Range(1, 24)] private int dias;

    private Color diaColor;


    void Start()
    {
        diaColor = camara.backgroundColor;
        StartCoroutine(CambiarColor(duracionDia));
    }

    IEnumerator CambiarColor(float tiempo)
    {
        Color colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;
        float duracionCiclo  = tiempo * 0.6f; 
        float duracionCambio = tiempo * 0.4f; 

        for (int i = 0; i < dias; i++)
        {
            yield return new WaitForSeconds(duracionCiclo);

            float tiempoTranscurrido = 0;
    
            while (tiempoTranscurrido < duracionCambio)
            {
                tiempoTranscurrido += Time.deltaTime;
                float t = tiempoTranscurrido / duracionCambio;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);
                camara.backgroundColor = Color.Lerp(camara.backgroundColor, colorDestino, smoothT);
                yield return null;
            }

            colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;
         
        }
    }
}
