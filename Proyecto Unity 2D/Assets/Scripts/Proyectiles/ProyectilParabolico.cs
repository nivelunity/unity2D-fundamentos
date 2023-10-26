using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilParabolico : Proyectil
{
    [SerializeField]
    [Range(0f, 90f)]
    private float launchAngle = 45f;

    protected override void Mover()
    {
        // Calcula la velocidad inicial basada en el ángulo y la fuerza de lanzamiento
        float launchAngleInRadians = launchAngle * Mathf.Deg2Rad;
        Vector2 launchVelocity = new Vector2(Mathf.Cos(launchAngleInRadians) * speed, Mathf.Sin(launchAngleInRadians) * speed);

        // Aplica la velocidad inicial al objeto proyectil
        rb.velocity = launchVelocity;
    }
}
