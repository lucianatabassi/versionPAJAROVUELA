using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESTEREO_CONTROL : MonoBehaviour
{
    public float sensibilidadMouse = 2.0f; // Sensibilidad del mouse
    public Transform ojoIzquierdo; // Referencia a la c�mara del ojo izquierdo
    public Transform ojoDerecho; // Referencia a la c�mara del ojo derecho

    private float rotacionX = 0.0f;
    private float rotacionY = 0.0f; // Variable para la rotaci�n horizontal*/


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    void Update()
    {
         //Captura el movimiento del mouse en los ejes X e Y
         rotacionY += Input.GetAxis("Mouse X") * sensibilidadMouse;
         rotacionX -= Input.GetAxis("Mouse Y") * sensibilidadMouse;
         rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f); // Limita la rotaci�n vertical

         // Aplica la rotaci�n en el eje Y a las c�maras de los ojos
         ojoIzquierdo.rotation = Quaternion.Euler(rotacionX, rotacionY, 0.0f);
         ojoDerecho.rotation = Quaternion.Euler(rotacionX, rotacionY, 0.0f);
     }
       
    

}
