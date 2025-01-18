// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class copa : MonoBehaviour
// {
//     public GameObject YouWin; // Referencia al panel YouWin

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.CompareTag("Player"))
//         {
//             // Desactiva el SpriteRenderer de la copa para hacerla invisible
//             GetComponent<SpriteRenderer>().enabled = false;

//             // Activa el objeto hijo (si lo hay) como la animación o efecto visual
//             gameObject.transform.GetChild(0).gameObject.SetActive(true);

//             // Muestra el panel de YouWin
//             YouWin.SetActive(true);

//             // Si quieres desactivar otros componentes (como Collider o Rigidbody), puedes hacerlo aquí:
//             // GetComponent<Collider2D>().enabled = false;
//             // GetComponent<Rigidbody2D>().isKinematic = true;
//         }
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copa : MonoBehaviour
{
    public GameObject YouWin; // Referencia al panel YouWin
    private SpriteRenderer spriteRenderer; // Referencia al SpriteRenderer de la copa

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Desactiva el SpriteRenderer de la copa para hacerla invisible
            spriteRenderer.enabled = false;

            // Activa el objeto hijo (si lo hay) como la animación o efecto visual
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // Muestra el panel de YouWin
            YouWin.SetActive(true);
        }
    }

    // Método para restaurar la copa a su estado visible
    public void ResetCopa()
    {
        // Reactiva el SpriteRenderer de la copa
        spriteRenderer.enabled = true;

        // Desactiva el objeto hijo (efecto visual)
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}