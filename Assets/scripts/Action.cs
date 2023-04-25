using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public GameObject ball;
    public Transform cam;
    public float ballDistance = 2f;
    public float ballForceMin = 150f;
    public float ballForceMax = 400f;
    public float ballForce;
    public float totalTimer = 3f;
    float currentTime = 0.0f;

    public bool holdingBall = true;
    Rigidbody ballRB;

    bool isPickableBall = false;
    public CanvasController canvasScript;
    public LayerMask pickableLayer;
    RaycastHit hit;

    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballRB.useGravity = false;
        canvasScript.OcultarCursor(true);
    }

    void Update()
    {
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, pickableLayer))
        {



            if (isPickableBall == false)
            {
                isPickableBall = true;
                canvasScript.ChangePickableBallColor(true);
            }

            if (holdingBall == false && isPickableBall && Input.GetKeyDown(KeyCode.E))
            {
                holdingBall = true;
                ballRB.useGravity = false;
                ballRB.velocity = Vector3.zero;
                ballRB.angularVelocity = Vector3.zero;
                ball.transform.localRotation = Quaternion.identity;
                cont.instance.canScore = false; 
                canvasScript.ChangePickableBallColor(false);
                canvasScript.OcultarCursor(true);
            }
        }
        else if (isPickableBall == true)
        {
            isPickableBall = false;
            canvasScript.ChangePickableBallColor(false);
        }

        if (holdingBall == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentTime = 0.0f;
                canvasScript.SetValueBar(0);
                canvasScript.ActivarSlider(true);

            }

            if (Input.GetMouseButton(0))
            {
                currentTime +=Time.deltaTime;
                ballForce = Mathf.Lerp(ballForceMin, ballForceMax, currentTime / totalTimer);
                canvasScript.SetValueBar(currentTime / totalTimer);

            }
            
            if (Input.GetMouseButtonUp(0))
            {
                holdingBall = false;
                ballRB.useGravity = true;
                ballRB.AddForce(cam.forward * ballForce);
                canvasScript.OcultarCursor(false);
                canvasScript.ActivarSlider(false);
            }
        }
    }

    private void LateUpdate()
    {
        if (holdingBall == true)
        {
            ball.transform.position = cam.position + cam.forward * ballDistance;
        }
    }
}
