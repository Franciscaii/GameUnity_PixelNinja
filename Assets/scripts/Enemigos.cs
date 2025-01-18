// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Enemigos : MonoBehaviour
// {
//     public float moveSpeed = 2f; // Velocidad del movimiento
//     public float moveDistance = 0.5f; // Distancia base que recorrerá (izquierda y derecha)

//     private Vector3 startPosition; // Posición inicial
//     private bool movingRight = true; // Indica si se está moviendo a la derecha

//     public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del personaje

//     void Start()
//     {
//         // Guarda la posición inicial
//         startPosition = transform.position;
//     }

//     void Update()
//     {
//         // Movimiento oscilante usando Mathf.PingPong
//         float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 8) - (moveDistance * 4); // Cuádruple de distancia
//         float newXPosition = startPosition.x + offset;

//         // Detectar si se está moviendo hacia la derecha o izquierda
//         if (newXPosition > transform.position.x)
//         {
//             // Moviéndose a la derecha
//             if (!movingRight)
//             {
//                 movingRight = true;
//                 spriteRenderer.flipX = false; // Voltea a la derecha
//             }
//         }
//         else if (newXPosition < transform.position.x)
//         {
//             // Moviéndose a la izquierda
//             if (movingRight)
//             {
//                 movingRight = false;
//                 spriteRenderer.flipX = true; // Voltea a la izquierda
//             }
//         }

//         // Actualizar posición
//         transform.position = new Vector3(newXPosition, startPosition.y, startPosition.z);
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Detecta si el objeto que colisiona es el jugador
//         if (collision.transform.CompareTag("Player"))
//         {
//             Debug.Log("Jugador eliminado por enemigo");
//             Destroy(collision.gameObject); // Destruye al jugador
        
//         }
//     }
// }





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Enemigos : MonoBehaviour
// {
//     public GameObject GameOver;        // Panel de Game Over
//     public GameObject Fin;           // Panel de Fin del juego
//     public float moveSpeed = 2f;       // Velocidad del movimiento
//     public float moveDistance = 0.5f; // Distancia base que recorrerá (izquierda y derecha)

//     private Vector3 startPosition;    // Posición inicial
//     private bool movingRight = true; // Indica si se está moviendo a la derecha
//     public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del enemigo

//     private Player playerScript;     // Referencia al script del jugador
//     private GameObject playerObject; // Referencia al objeto del jugador

//     void Start()
//     {
//         // Guarda la posición inicial del enemigo
//         startPosition = transform.position;

//         // Encuentra al jugador por su etiqueta y referencia su script
//         playerObject = GameObject.FindGameObjectWithTag("Player");
//         if (playerObject != null)
//         {
//             playerScript = playerObject.GetComponent<Player>();
//         }
//     }

//     void Update()
//     {
//         // Movimiento oscilante usando Mathf.PingPong
//         float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 8) - (moveDistance * 4); // Cuádruple de distancia
//         float newXPosition = startPosition.x + offset;

//         // Detectar si se está moviendo hacia la derecha o izquierda
//         if (newXPosition > transform.position.x)
//         {
//             // Moviéndose a la derecha
//             if (!movingRight)
//             {
//                 movingRight = true;
//                 spriteRenderer.flipX = false; // Voltea a la derecha
//             }
//         }
//         else if (newXPosition < transform.position.x)
//         {
//             // Moviéndose a la izquierda
//             if (movingRight)
//             {
//                 movingRight = false;
//                 spriteRenderer.flipX = true; // Voltea a la izquierda
//             }
//         }

//         // Actualizar posición
//         transform.position = new Vector3(newXPosition, startPosition.y, startPosition.z);

//         // Reiniciar jugador al presionar "X" si está en estado Game Over
//         if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
//         {
//             GameOver.SetActive(false); // Oculta el panel Game Over
//             playerScript.RestartPlayer(); // Llama al método RestartPlayer del script Player
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         // Detecta si el objeto que colisiona es el jugador
//         if (collision.transform.CompareTag("Player"))
//         {
//             Debug.Log("Jugador eliminado por enemigo");

//             // Desactiva visualmente al jugador
//             SpriteRenderer playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();
//             if (playerSprite != null)
//             {
//                 playerSprite.enabled = false; // Desactiva el sprite del jugador
//             }

//             // Desactiva las funcionalidades del jugador
//             playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Detén el movimiento
//             playerObject.GetComponent<Player>().start = false; // Bloquea el movimiento del jugador

//             // Muestra el panel Game Over
//             GameOver.SetActive(true);
//         }
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject GameOver;        // Panel de Game Over
    public GameObject Fin;             // Panel de Fin del juego
    public float moveSpeed = 2f;       // Velocidad del movimiento
    public float moveDistance = 0.5f;  // Distancia base que recorrerá (izquierda y derecha)

    private Vector3 startPosition;     // Posición inicial
    private bool movingRight = true;   // Indica si se está moviendo a la derecha
    public SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer del enemigo

    private Player playerScript;       // Referencia al script del jugador
    private GameObject playerObject;   // Referencia al objeto del jugador

    void Start()
    {
        // Guarda la posición inicial del enemigo
        startPosition = transform.position;

        // Encuentra al jugador por su etiqueta y referencia su script
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<Player>();
        }

        // Asegurarse de que el panel Fin esté desactivado al inicio
        if (Fin != null)
        {
            Fin.SetActive(false);
        }
    }

    void Update()
    {
        // Movimiento oscilante usando Mathf.PingPong
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 8) - (moveDistance * 4); // Cuádruple de distancia
        float newXPosition = startPosition.x + offset;

        // Detectar si se está moviendo hacia la derecha o izquierda
        if (newXPosition > transform.position.x)
        {
            // Moviéndose a la derecha
            if (!movingRight)
            {
                movingRight = true;
                spriteRenderer.flipX = false; // Voltea a la derecha
            }
        }
        else if (newXPosition < transform.position.x)
        {
            // Moviéndose a la izquierda
            if (movingRight)
            {
                movingRight = false;
                spriteRenderer.flipX = true; // Voltea a la izquierda
            }
        }

        // Actualizar posición
        transform.position = new Vector3(newXPosition, startPosition.y, startPosition.z);

        // Reiniciar jugador al presionar "X" si está en estado Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            GameOver.SetActive(false); // Oculta el panel Game Over
            playerScript.RestartPlayer(); // Llama al método RestartPlayer del script Player
        }

        // Mostrar el panel Fin al presionar "Z" si está en estado Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            GameOver.SetActive(false); // Oculta el panel Game Over
            if (Fin != null)
            {
                Fin.SetActive(true); // Muestra el panel Fin
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta si el objeto que colisiona es el jugador
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Jugador eliminado por enemigo");

            // Desactiva visualmente al jugador
            SpriteRenderer playerSprite = collision.gameObject.GetComponent<SpriteRenderer>();
            if (playerSprite != null)
            {
                playerSprite.enabled = false; // Desactiva el sprite del jugador
            }

            // Desactiva las funcionalidades del jugador
            playerObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Detén el movimiento
            playerObject.GetComponent<Player>().start = false; // Bloquea el movimiento del jugador

            // Muestra el panel Game Over
            GameOver.SetActive(true);
        }
    }
}
