// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Codigopueas : MonoBehaviour
// {   public GameObject GameOver;      // Panel de Game Over
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

// public class Codigopueas : MonoBehaviour
// {
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject Fin;          // Panel de Fin del juego 
//     private Player playerScript;    // Referencia al script del jugador

//     void Start()
//     {
//         // Encontrar al jugador y obtener el script
//         GameObject playerObject = GameObject.FindWithTag("Player");
//         if (playerObject != null)
//         {
//             playerScript = playerObject.GetComponent<Player>();
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

//     void Update()
//     {
//         // Reiniciar el jugador al presionar la tecla X si aparece Game Over
//         if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
//         {
//             if (playerScript != null)
//             {
//                 playerScript.RestartPlayer(); // Llamar al método para reiniciar
//             }
//         }
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigopueas : MonoBehaviour
{
    public GameObject GameOver;      // Panel de Game Over
    public GameObject Fin;          // Panel de Fin del juego 
    private Player playerScript;    // Referencia al script del jugador

    void Start()
    {
        // Encontrar al jugador y obtener el script
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerScript = playerObject.GetComponent<Player>();
        }

        // Asegurarse de que el panel Fin esté desactivado al inicio
        Fin.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");

            // Hacer invisible al jugador
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // Mostrar el panel de Game Over
            GameOver.SetActive(true);

            // Detener el movimiento del jugador
            if (playerScript != null)
            {
                playerScript.start = false; // Bloquear movimiento
            }
        }
    }

    void Update()
    {
        // Reiniciar el jugador al presionar la tecla X si aparece Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            if (playerScript != null)
            {
                playerScript.RestartPlayer(); // Llamar al método para reiniciar
                GameOver.SetActive(false);   // Ocultar el panel de Game Over
            }
        }

        // Cambiar al panel Fin al presionar la tecla Z si aparece Game Over
        if (GameOver.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            GameOver.SetActive(false); // Ocultar el panel de Game Over
            Fin.SetActive(true);       // Mostrar el panel Fin
        }
    }
}

