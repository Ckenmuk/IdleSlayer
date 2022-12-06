using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsOnOff : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    [SerializeField] private AudioSource MainTheme;
    [SerializeField] private AudioSource CoinCollect;
    [SerializeField] private AudioSource SwordHit;
    [SerializeField] private AudioSource EnemyKill;


    public void ChangeSound()
    {
        if (text.text.Contains("off"))
        {
            text.text = text.text.Replace("off", "on");
            icon.sprite = Resources.Load<Sprite>("Sprites/sound");
        }
        else
        {
            text.text = text.text.Replace("on", "off");
            icon.sprite = Resources.Load<Sprite>("Sprites/soundOff");
        }

        SetMute(gameObject.name);
    }

    private void SetMute(string name)
    {
        if (name.Contains("Music"))
        {
            MainTheme.mute = !MainTheme.mute;
        }
        else if (name.Contains("Sound"))
        {
            CoinCollect.mute = !CoinCollect.mute;
            SwordHit.mute = !SwordHit.mute;
            EnemyKill.mute = !EnemyKill.mute;
        }
    }
    

}
