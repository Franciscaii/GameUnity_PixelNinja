// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemySpike2 : MonoBehaviour
// {
//     public GameObject GameOver;      // Panel de Game Over
//     public float moveSpeed = 0.2f; // Velocidad del movimiento
//     public float moveDistance = 1f; // Distancia en metros que recorrerá (arriba y abajo)

//     private Vector3 startPosition; // Posición inicial

//     void Start()
//     {
//         // Guarda la posición inicial
//         startPosition = transform.position;
//     }

//     void Update()
//     {
//         // Movimiento oscilante usando Mathf.PingPong en el eje Y
//         float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
//         transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);
//     }


//     // Detectar colisión con el jugador
//     private void OnCollisionEnter2D(Collision2D collision)
//     {
    
//         if(collision.transform.CompareTag("Player"))
//         {
//             Debug.Log("Player Damaged");
//             Destroy(collision.gameObject);
//             GameOver.SetActive(true);
//         }
//     }
// }



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemySpike2 : MonoBehaviour
// {
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject Fin;           // Panel de Fin del juego 
//     private Player playerScript;     // Referencia al script del jugador

//     public float moveSpeed = 0.2f;   // Velocidad del movimiento
//     public float moveDistance = 1f;  // Distancia en metros que recorrerá (arriba y abajo)

//     private Vector3 startPosition;   // Posición inicial

//     void Start()
//     {
//         // Guarda la posición inicial
//         startPosition = transform.position;

//         // Encontrar al jugador y obtener el script
//         GameObject playerObject = GameObject.FindWithTag("Player");
//         if (playerObject != null)
//         {
//             playerScript = playerObject.GetComponent<Player>();
//         }
//     }

//     void Update()
//     {
//         // Movimiento oscilante en el eje Y
//         float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
//         transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);

//         // Reiniciar el jugador al presionar la tecla X si aparece Game Over
//         if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
//         {
//             if (playerScript != null)
//             {
//                 playerScript.RestartPlayer(); // Llamar al método para reiniciar
//             }
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.transform.CompareTag("Player"))
//         {
//             Debug.Log("Player Damaged");

//             // Hacer invisible al jugador
//             collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

//             // Mostrar el panel de Game Over
//             GameOver.SetActive(true);

//             // Detener el movimiento del jugador
//             if (playerScript != null)
//             {
//                 playerScript.start = false; // Bloquear movimiento
//             }
//         }
//     }
// }




using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike2 : MonoBehaviour
{
    public GameObject GameOver;      // Panel de Game Over
    public GameObject Fin;           // Panel de Fin del juego 
    private Player playerScript;     // Referencia al script del jugador

    public float moveSpeed = 0.2f;   // Velocidad del movimiento
    public float moveDistance = 1f;  // Distancia en metros que recorrerá (arriba y abajo)

    private Vector3 startPosition;   // Posición inicial

    void Start()
    {
        // Guarda la posición inicial
        startPosition = transform.position;

        // Encontrar al jugador y obtener el script
        GameObject playerObject = GameObject.FindWithTag("Player");
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
        // Movimiento oscilante en el eje Y
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2) - moveDistance;
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);

        // Reiniciar el jugador al presionar la tecla X si aparece Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            if (playerScript != null)
            {
                playerScript.RestartPlayer(); // Llamar al método para reiniciar
                GameOver.SetActive(false);   // Ocultar el panel Game Over
            }
        }

        // Mostrar el panel Fin al presionar la tecla Z si aparece Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            GameOver.SetActive(false); // Ocultar el panel Game Over
            if (Fin != null)
            {
                Fin.SetActive(true);   // Mostrar el panel Fin
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");

            // Hacer invisible al jugador
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // Mostrar el panel de Game Over
            if (GameOver != null)
            {
                GameOver.SetActive(true);
            }

            // Detener el movimiento del jugador
            if (playerScript != null)
            {
                playerScript.start = false; // Bloquear movimiento
            }
        }
    }
}