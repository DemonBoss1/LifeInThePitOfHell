using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        public Image image;
        public void SetValue(float value){
            image.fillAmount = value;
        }
    }
}
