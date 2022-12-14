using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnOff : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    public void ChangeSound()
    {
        if (text.text.Contains("off"))
        {
            text.text = text.text.Replace("off", "on");
            icon.sprite = Resources.Load<Sprite>("Sprites/sound");
            AudioListener.volume = 1;
        }
        else
        {
            text.text = text.text.Replace("on", "off");
            icon.sprite = Resources.Load<Sprite>("Sprites/soundOff");
            AudioListener.volume = 0;
        }
    }


    

}
