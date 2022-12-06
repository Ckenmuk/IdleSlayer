using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject CoinCollect;
    [SerializeField] private GameObject SwordHit;
    [SerializeField] private GameObject EnemyKill;

    [SerializeField] private AudioSource MainTheme;


    public bool musicOn;
    public bool soundsOn;

    private void Update()
    {
        MainTheme.mute = !musicOn;
        CoinCollect.GetComponent<AudioSource>().mute = !soundsOn;
        SwordHit.GetComponent<AudioSource>().mute = !soundsOn;
        EnemyKill.GetComponent<AudioSource>().mute = !soundsOn;
    }
}
