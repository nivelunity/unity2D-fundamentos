using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float coyoteConfig = 0.1f;

    private Jugador jugador;
    private float coyoteTime;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void Awake()
    {
        jugador = GetComponent<Jugador>();
    }

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        puedoSaltar = IsGrounded();

        if (puedoSaltar)
        {
            coyoteTime = Time.time + coyoteConfig;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time <= coyoteTime))
        {
            saltando = true;
            Debug.Log("Saltando");

            if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (saltando)
        {
            Debug.Log("Aplicar fuerza de salto");
            miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(miAudioSource.isPlaying) { return; }
        miAudioSource.PlayOneShot(jugador.PerfilJugador.CollisionSFX);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
