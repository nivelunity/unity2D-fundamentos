using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField] float rayDistance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float coyoteConfig = 0.1f;
    [SerializeField] int maxJumpCount = 2;
    [SerializeField] GameObject jumpTrail;

    [SerializeField] float maxJumpForce = 10f;
    [SerializeField] float jumpForceIncreaseSpeed = 2f;

    private Jugador jugador;
    private float coyoteTime;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;
    private int jumpCount;
    private bool canDash;
    private bool canDown;
    private float auxForce = 5f;

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
        jumpTrail.SetActive(!puedoSaltar);

        if (puedoSaltar)
        {
            coyoteTime = Time.time + coyoteConfig;
            jumpCount = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            auxForce = Mathf.Min(auxForce + jumpForceIncreaseSpeed * Time.deltaTime, maxJumpForce);
            Debug.Log(auxForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && (Time.time <= coyoteTime) && (jumpCount < maxJumpCount))
        {
            saltando = true;
            canDash = true;
            canDown = true;

            jumpCount++;

            if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(jugador.PerfilJugador.JumpSFX);
        }


        if (canDash && !puedoSaltar && Input.GetKeyDown(KeyCode.E))
        {
           canDash = false;
        }

        if (canDown && !puedoSaltar && Input.GetKeyDown(KeyCode.R))
        {
           canDown = false;
        }
    }

    private void FixedUpdate()
    {
        if (saltando)
        {
            Debug.Log("Aplicar fuerza de salto");
            miRigidbody2D.AddForce(Vector2.up * Mathf.Max(jugador.PerfilJugador.FuerzaSalto,auxForce), ForceMode2D.Impulse);
            saltando = false;
        }

        if(!canDash)
        {
            Debug.Log("DASH");
            miRigidbody2D.velocity = new Vector2(25f * Input.GetAxisRaw("Horizontal"), miRigidbody2D.velocity.y);
            canDash = true;
        }


        if (!canDown)
        {
            Debug.Log("DOWN");
            miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, -25f);
            canDown = true;
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
