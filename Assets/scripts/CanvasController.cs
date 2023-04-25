using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Image imgSelector;
    public Slider sliderBar;

    public void ChangePickableBallColor(bool isSelect)
    {
        if (isSelect)
        {
            imgSelector.color = Color.blue;
        }
        else
        {
            imgSelector.color = Color.green;
        }
    }
    public void OcultarCursor(bool ocultar)
    {
        imgSelector.enabled = !ocultar;
    }
    //

    public void ActivarSlider(bool activar)
    {
        sliderBar.gameObject.SetActive(activar);
    }

    public void SetValueBar(float vld)
    {
        sliderBar.value = vld;
    }


}