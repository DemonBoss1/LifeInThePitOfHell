using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance {get; private set;}
    public Image image;

    private void Awake() {
        instance = this;
    }
    public void SetValue(float value){
        image.fillAmount = value;
    }
}
