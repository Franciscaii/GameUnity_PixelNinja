// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public float runSpeed = 1f; // Velocidad de movimiento
//     public float jumpForce = 300f; // Fuerza de salto (ajustar para saltos más largos)

//     private Rigidbody2D rb2D; // Referencia al Rigidbody2D

//     public SpriteRenderer spriteRenderer;

//     public Animator animator;
    
//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {
//         // Movimiento hacia la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
//             spriteRenderer.flipX=false;
//             animator.SetBool("Run",true);
//             animator.SetBool("Jump",false);
//         }
//         // Movimiento hacia la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
//             spriteRenderer.flipX=true;
//             animator.SetBool("Run",true);
//             animator.SetBool("Jump",false);
//         }
//         // Salto con AddForce cuando se presiona "W" o "Space" (sin retraso)
//         else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && CheckGround.isGrounded)
//         {
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump",true);
//             animator.SetBool("Run",false);

//         }
//         else if(CheckGround.isGrounded==true)
//         {
        
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y); 
//             animator.SetBool("Run", false);
//             animator.SetBool("Jump",false);
//         }  
//     }
// }




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public float runSpeed = 1f; // Velocidad de movimiento
//     public float jumpForce = 300f; // Fuerza de salto (ajustar para saltos más largos)

//     private Rigidbody2D rb2D; // Referencia al Rigidbody2D

//     public SpriteRenderer spriteRenderer;

//     public Animator animator;

//     private bool isRunning = false; // Para gestionar el estado de correr

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {
//         // Almacenamos la dirección del movimiento
//         float horizontal = 0f;

//         // Detectar movimiento hacia la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f; // Movimiento positivo en X
//             spriteRenderer.flipX = false;
//         }
//         // Detectar movimiento hacia la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f; // Movimiento negativo en X
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Detectar salto si está en el suelo
//         if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && CheckGround.isGrounded)
//         {
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     void Update()
//     {
//         // Asegurarse de detener el movimiento si no se presiona ninguna tecla
//         if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) && 
//             !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//             CheckGround.isGrounded)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             animator.SetBool("Run", false);
//         }
//     }
// }



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public float runSpeed = 1f; // Velocidad de movimiento
//     public float jumpForce = 300f; // Fuerza de salto (ajustar para saltos más largos)

//     private Rigidbody2D rb2D; // Referencia al Rigidbody2D

//     public SpriteRenderer spriteRenderer;

//     public Animator animator;

//     private bool isRunning = false; // Para gestionar el estado de correr

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {
//         // Almacenamos la dirección del movimiento
//         float horizontal = 0f;

//         // Detectar movimiento hacia la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f; // Movimiento positivo en X
//             spriteRenderer.flipX = false;
//         }
//         // Detectar movimiento hacia la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f; // Movimiento negativo en X
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Detectar salto (forzado, sin depender completamente de CheckGround.isGrounded)
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             // Reiniciar la velocidad vertical para evitar acumulación de fuerzas
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     void Update()
//     {
//         // Asegurarse de detener el movimiento si no se presiona ninguna tecla
//         if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) && 
//             !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//             CheckGround.isGrounded)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             animator.SetBool("Run", false);
//         }
//     }
// }





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class Player : MonoBehaviour
// {
//     public GameObject MenuPrincipal;
    
//     public float runSpeed = 1f; // Velocidad de movimiento
//     public float jumpForce = 300f; // Fuerza de salto (ajustar para saltos más largos)

//     private Rigidbody2D rb2D; // Referencia al Rigidbody2D

//     public SpriteRenderer spriteRenderer;

//     public Animator animator;

//     private bool isRunning = false; // Para gestionar el estado de correr

//     public bool start = false; // Variable para habilitar las funcionalidades del jugador

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();
//     }

//     void Update()
//     {
//         // Detectar si se presiona la tecla X para activar las funcionalidades del jugador
//         if (!start && Input.GetKeyDown(KeyCode.X))
//         {
//             start = true;
//             MenuPrincipal.SetActive(false);
//         }

//         // Solo se permite actualizar animaciones y detener al jugador si `start` es true
//         if (start)
//         {
//             // Asegurarse de detener el movimiento si no se presiona ninguna tecla
//             if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
//                 !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//                 CheckGround.isGrounded)
//             {
//                 rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//                 animator.SetBool("Run", false);
//             }
//         }
//     }

//     void FixedUpdate()
//     {
//         // No permitir movimiento ni saltos si `start` es false
//         if (!start)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             return;
//         }

//         // Almacenamos la dirección del movimiento
//         float horizontal = 0f;

//         // Detectar movimiento hacia la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f; // Movimiento positivo en X
//             spriteRenderer.flipX = false;
//         }
//         // Detectar movimiento hacia la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f; // Movimiento negativo en X
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Detectar salto (forzado, sin depender completamente de CheckGround.isGrounded)
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             // Reiniciar la velocidad vertical para evitar acumulación de fuerzas
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }
// } 





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public GameObject MenuPrincipal; // Panel del menú principal
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject YouWin;        // Panel de You Win

//     public float runSpeed = 1f;      // Velocidad de movimiento
//     public float jumpForce = 300f;   // Fuerza de salto

//     private Rigidbody2D rb2D;        // Referencia al Rigidbody2D
//     public SpriteRenderer spriteRenderer;
//     public Animator animator;

//     private bool isRunning = false;  // Estado de correr
//     public bool start = false;       // Variable para habilitar las funcionalidades del jugador

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();

//         // Asegurarnos de que solo el panel MenuPrincipal esté activo al inicio
//         MenuPrincipal.SetActive(true);
//         GameOver.SetActive(false);
//         YouWin.SetActive(false);
//     }

//     void Update()
//     {
//         // Activar el juego y ocultar el menú principal al presionar la tecla X
//         if (!start && Input.GetKeyDown(KeyCode.X))
//         {
//             start = true;
//             MenuPrincipal.SetActive(false); // Oculta el menú principal
//         }

//         // Solo se permite movimiento y animaciones si el juego ha iniciado
//         if (start)
//         {
//             // Detener movimiento si no se presiona ninguna tecla
//             if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
//                 !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//                 CheckGround.isGrounded)
//             {
//                 rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//                 animator.SetBool("Run", false);
//             }
//         }
//     }

//     void FixedUpdate()
//     {
//         // Bloquear movimiento si el juego no ha iniciado
//         if (!start)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             return;
//         }

//         // Movimiento horizontal
//         float horizontal = 0f;

//         // Movimiento a la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f;
//             spriteRenderer.flipX = false;
//         }
//         // Movimiento a la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f;
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Saltar
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     // Detectar colisión con la Copa (objeto con el tag "Copa")
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         // Comprobar si el objeto con el que colisionó tiene el tag "Copa"
//         if (other.CompareTag("copa"))
//         {
//             // Mostrar el panel de "You Win"
//             YouWin.SetActive(true);

//             // Ocultar el panel de "Menu Principal"
//             MenuPrincipal.SetActive(false);

//             // Detener el movimiento del jugador (si lo deseas)
//             rb2D.velocity = Vector2.zero;

//             // También puedes detener otras acciones del jugador si lo deseas
//             start = false;
//         }
//     }
    
// }




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public GameObject MenuPrincipal; // Panel del menú principal
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject YouWin;        // Panel de You Win

//     public float runSpeed = 1f;      // Velocidad de movimiento
//     public float jumpForce = 300f;   // Fuerza de salto

//     private Rigidbody2D rb2D;        // Referencia al Rigidbody2D
//     public SpriteRenderer spriteRenderer;
//     public Animator animator;

//     private bool isRunning = false;  // Estado de correr
//     public bool start = false;       // Variable para habilitar las funcionalidades del jugador
//     private Vector3 initialPosition; // Posición inicial del jugador

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();

//         // Guardar la posición inicial del jugador
//         initialPosition = transform.position;

//         // Asegurarnos de que solo el panel MenuPrincipal esté activo al inicio
//         MenuPrincipal.SetActive(true);
//         GameOver.SetActive(false);
//         YouWin.SetActive(false);
//     }

//     void Update()
//     {
//         // Activar el juego y ocultar el menú principal al presionar la tecla X
//         if (!start && Input.GetKeyDown(KeyCode.X))
//         {
//             start = true;
//             MenuPrincipal.SetActive(false); // Oculta el menú principal
//         }

//         // Solo se permite movimiento y animaciones si el juego ha iniciado
//         if (start)
//         {
//             // Detener movimiento si no se presiona ninguna tecla
//             if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
//                 !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//                 CheckGround.isGrounded)
//             {
//                 rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//                 animator.SetBool("Run", false);
//             }
//         }
//     }

//     void FixedUpdate()
//     {
//         // Bloquear movimiento si el juego no ha iniciado
//         if (!start)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             return;
//         }

//         // Movimiento horizontal
//         float horizontal = 0f;

//         // Movimiento a la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f;
//             spriteRenderer.flipX = false;
//         }
//         // Movimiento a la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f;
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Saltar
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     // Método para reiniciar la posición y estado del jugador
//     public void RestartPlayer()
//     {
//         transform.position = initialPosition; // Restaurar posición inicial
//         rb2D.velocity = Vector2.zero;        // Detener cualquier movimiento
//         spriteRenderer.enabled = true;       // Hacer visible al jugador
//         GameOver.SetActive(false);           // Ocultar el panel Game Over
//         start = true;                        // Permitir que el jugador se mueva nuevamente
//     }
// }



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public GameObject MenuPrincipal; // Panel del menú principal
//     public GameObject Instrucciones; // Panel del menú principal
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject YouWin;        // Panel de You Win

//     public float runSpeed = 1f;      // Velocidad de movimiento
//     public float jumpForce = 300f;   // Fuerza de salto

//     private Rigidbody2D rb2D;        // Referencia al Rigidbody2D
//     public SpriteRenderer spriteRenderer;
//     public Animator animator;

//     private bool isRunning = false;  // Estado de correr
//     public bool start = false;       // Variable para habilitar las funcionalidades del jugador
//     private Vector3 initialPosition; // Posición inicial del jugador
//     private copa copaScript;         // Referencia al script copa

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();

//         // Guardar la posición inicial del jugador
//         initialPosition = transform.position;

//         // Asegurarnos de que solo el panel MenuPrincipal esté activo al inicio
//         MenuPrincipal.SetActive(true);
//         GameOver.SetActive(false);
//         YouWin.SetActive(false);

//         // Obtener referencia al script copa
//         copaScript = FindObjectOfType<copa>();
//     }

//     void Update()
//     {
//         // Activar el juego y ocultar el menú principal al presionar la tecla X
//         if (!start && Input.GetKeyDown(KeyCode.X))
//         {
//             start = true;
//             MenuPrincipal.SetActive(false); // Oculta el menú principal
//         }

//         // Solo se permite movimiento y animaciones si el juego ha iniciado
//         if (start)
//         {
//             // Detener movimiento si no se presiona ninguna tecla
//             if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
//                 !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//                 CheckGround.isGrounded)
//             {
//                 rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//                 animator.SetBool("Run", false);
//             }
//         }

//         // Si se muestra el panel YouWin y se presiona la tecla X
//         if (YouWin.activeSelf && Input.GetKeyDown(KeyCode.X))
//         {
//             RestartPlayer();  // Reinicia la posición del jugador
//             copaScript.ResetCopa(); // Restablece la copa a su estado visible
//             YouWin.SetActive(false); // Oculta el panel YouWin
//         }
//     }

//     void FixedUpdate()
//     {
//         // Bloquear movimiento si el juego no ha iniciado
//         if (!start)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             return;
//         }

//         // Movimiento horizontal
//         float horizontal = 0f;

//         // Movimiento a la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f;
//             spriteRenderer.flipX = false;
//         }
//         // Movimiento a la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f;
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Saltar
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     // Método para reiniciar la posición y estado del jugador
//     public void RestartPlayer()
//     {
//         transform.position = initialPosition; // Restaurar posición inicial
//         rb2D.velocity = Vector2.zero;        // Detener cualquier movimiento
//         spriteRenderer.enabled = true;       // Hacer visible al jugador
//         GameOver.SetActive(false);           // Ocultar el panel Game Over
//         start = true;                        // Permitir que el jugador se mueva nuevamente
//     }
// }






// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public GameObject MenuPrincipal; // Panel del menú principal
//     public GameObject Instrucciones; // Panel de instrucciones
//     public GameObject GameOver;      // Panel de Game Over
//     public GameObject YouWin;        // Panel de You Win

//     public float runSpeed = 1f;      // Velocidad de movimiento
//     public float jumpForce = 300f;   // Fuerza de salto

//     private Rigidbody2D rb2D;        // Referencia al Rigidbody2D
//     public SpriteRenderer spriteRenderer;
//     public Animator animator;

//     private bool isRunning = false;  // Estado de correr
//     public bool start = false;       // Variable para habilitar las funcionalidades del jugador
//     private Vector3 initialPosition; // Posición inicial del jugador
//     private copa copaScript;         // Referencia al script copa

//     void Start()
//     {
//         // Obtenemos el componente Rigidbody2D del objeto
//         rb2D = GetComponent<Rigidbody2D>();

//         // Guardar la posición inicial del jugador
//         initialPosition = transform.position;

//         // Asegurarnos de que solo el panel MenuPrincipal esté activo al inicio
//         MenuPrincipal.SetActive(true);
//         Instrucciones.SetActive(false);
//         GameOver.SetActive(false);
//         YouWin.SetActive(false);

//         // Obtener referencia al script copa
//         copaScript = FindObjectOfType<copa>();
//     }

//     void Update()
//     {
//         // Activar el juego y ocultar el menú principal al presionar la tecla X
//         if (!start && Input.GetKeyDown(KeyCode.X))
//         {
//             start = true;
//             MenuPrincipal.SetActive(false); // Oculta el menú principal
//         }

//         // Mostrar el panel de instrucciones al presionar Z si está en el menú principal
//         if (!start && Input.GetKeyDown(KeyCode.Z))
//         {
//             MenuPrincipal.SetActive(false); // Oculta el menú principal
//             Instrucciones.SetActive(true);  // Muestra el panel de instrucciones

            

//         }

        

//         // Solo se permite movimiento y animaciones si el juego ha iniciado
//         if (start)
//         {
//             // Detener movimiento si no se presiona ninguna tecla
//             if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
//                 !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
//                 CheckGround.isGrounded)
//             {
//                 rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//                 animator.SetBool("Run", false);
//             }
//         }

//         // Validar si se está en el panel Instrucciones y el usuario presiona la tecla Z vuelve a menuprincipal
//         if (Instrucciones.activeSelf && Input.GetKeyDown(KeyCode.Z))
//         {
//             Instrucciones.SetActive(false);
//             MenuPrincipal.SetActive(true);
//         }


//         // Si se muestra el panel YouWin y se presiona la tecla X
//         if (YouWin.activeSelf && Input.GetKeyDown(KeyCode.X))
//         {
//             RestartPlayer();  // Reinicia la posición del jugador
//             copaScript.ResetCopa(); // Restablece la copa a su estado visible
//             YouWin.SetActive(false); // Oculta el panel YouWin
//         }
//     }


    
//     void FixedUpdate()
//     {
//         // Bloquear movimiento si el juego no ha iniciado
//         if (!start)
//         {
//             rb2D.velocity = new Vector2(0, rb2D.velocity.y);
//             return;
//         }

//         // Movimiento horizontal
//         float horizontal = 0f;

//         // Movimiento a la derecha
//         if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
//         {
//             horizontal = 1f;
//             spriteRenderer.flipX = false;
//         }
//         // Movimiento a la izquierda
//         else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
//         {
//             horizontal = -1f;
//             spriteRenderer.flipX = true;
//         }

//         // Aplicar movimiento horizontal
//         rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);

//         // Gestionar animaciones de correr
//         isRunning = horizontal != 0;
//         animator.SetBool("Run", isRunning);

//         // Saltar
//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
//         {
//             rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
//             rb2D.AddForce(new Vector2(0, jumpForce));
//             animator.SetBool("Jump", true);
//         }
//         else if (CheckGround.isGrounded)
//         {
//             animator.SetBool("Jump", false);
//         }
//     }

//     // Método para reiniciar la posición y estado del jugador
//     public void RestartPlayer()
//     {
//         transform.position = initialPosition; // Restaurar posición inicial
//         rb2D.velocity = Vector2.zero;        // Detener cualquier movimiento
//         spriteRenderer.enabled = true;       // Hacer visible al jugador
//         GameOver.SetActive(false);           // Ocultar el panel Game Over
//         start = true;                        // Permitir que el jugador se mueva nuevamente
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Instrucciones;
    public GameObject GameOver;
    public GameObject YouWin;

    public float runSpeed = 1f;
    public float jumpForce = 150f;

    private Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private bool isRunning = false;
    public bool start = false;
    private Vector3 initialPosition;
    private copa copaScript;

    private bool jumpPressed = false; // Nueva variable para manejar el salto
    private enum MenuState { Principal, Instrucciones, Juego }
    private MenuState currentMenuState;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        currentMenuState = MenuState.Principal;

        MenuPrincipal.SetActive(true);
        Instrucciones.SetActive(false);
        GameOver.SetActive(false);
        YouWin.SetActive(false);

        copaScript = FindObjectOfType<copa>();
    }

    void Update()
    {
        switch (currentMenuState)
        {
            case MenuState.Principal:
                if (Input.GetKeyDown(KeyCode.X))
                {
                    start = true;
                    MenuPrincipal.SetActive(false);
                    currentMenuState = MenuState.Juego;
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    MenuPrincipal.SetActive(false);
                    Instrucciones.SetActive(true);
                    currentMenuState = MenuState.Instrucciones;
                }
                break;

            case MenuState.Instrucciones:
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Instrucciones.SetActive(false);
                    MenuPrincipal.SetActive(true);
                    currentMenuState = MenuState.Principal;
                }
                break;

            case MenuState.Juego:
                break;
        }

        if (start)
        {
            if (!Input.GetKey("d") && !Input.GetKey(KeyCode.RightArrow) &&
                !Input.GetKey("a") && !Input.GetKey(KeyCode.LeftArrow) &&
                CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                animator.SetBool("Run", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                jumpPressed = true; // Detecta el salto
            }
        }

        if (YouWin.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            RestartPlayer();
            copaScript.ResetCopa();
            YouWin.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (!start)
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            return;
        }

        float horizontal = 0f;

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
            spriteRenderer.flipX = true;
        }

        rb2D.velocity = new Vector2(horizontal * runSpeed, rb2D.velocity.y);
        isRunning = horizontal != 0;
        animator.SetBool("Run", isRunning);

        if (CheckGround.isGrounded && jumpPressed)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jump", true);
            jumpPressed = false; // Resetea el salto
        }
        else if (CheckGround.isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    public void RestartPlayer()
    {
        transform.position = initialPosition;
        rb2D.velocity = Vector2.zero;
        spriteRenderer.enabled = true;
        GameOver.SetActive(false);
        start = true;
    }
}