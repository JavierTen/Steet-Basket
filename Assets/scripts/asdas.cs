using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdas : MonoBehaviour
{
    public ParticleSystem winEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && cont.instance.canScore == true)
        {
            Debug.Log("CANASTA");
            winEffect.Play();
        }
    }
}
