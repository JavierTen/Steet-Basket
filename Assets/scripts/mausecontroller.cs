using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mausecontroller : MonoBehaviour
{
    public float mouseSpeed = 100f; // velocidad del mause
    public Transform cam; //rotacion local de la camra

    float mouseX;
    float mouseY;
    float yReal = 0.0f; //vamos a manipular la cam rotacion, por defecto la colocamos en 0
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//para que el cursor desaparezca
    }
    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;//GetAxis nos da normalizada el agarre del mause
                                                                        //mouseSpeed: para que la coordenada se calcule segun la velocidad que emos dicho //Time, velocidad en la que se ejcuta el Update
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
        yReal -= mouseY;//es para que la camara vaya hacia arriba o abajo dependiendo el movimiento del mouse

        yReal = Mathf.Clamp(yReal, -90f, 90f);
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);//solo podemos rotar la cam en ese eje
        transform.Rotate(Vector3.up * mouseX); 
       
    }
}
