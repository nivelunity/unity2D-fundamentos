using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    private float speed = 10f;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Mover();
    }

    private void Mover()
    {
        // Establece la dirección del proyectil (por ejemplo, hacia la izquierda en X)
        Vector2 direction = Vector2.left;
        // Aplica la velocidad al Rigidbody
        rb.velocity = direction * speed;
    }


}
