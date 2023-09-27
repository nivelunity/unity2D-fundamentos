using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [SerializeField]
    [Tooltip("Rango de experiencia necesaria para el proximo nivel 10 a 50")]
    [Range(10, 50)]
    private int experienciaProximoNivel;
    public int ExperienciaProximoNivel { get => experienciaProximoNivel; set => experienciaProximoNivel = value; }

    [SerializeField]
    [Tooltip("Como aumenta la experiencia nivel a nivel")]
    [Range(10, 2000)]
    private int escalarExperiencia;
    public int EscalarExperiencia { get => escalarExperiencia; set => escalarExperiencia = value; }

    private int nivel;
    public int Nivel { get => nivel; set => nivel = value; }


    private int experiencia;
    public int Experiencia { get => experiencia; set => experiencia = value; }
  
}
