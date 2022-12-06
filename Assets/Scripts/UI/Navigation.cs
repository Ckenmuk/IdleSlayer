using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] private GameObject improvements;
    [SerializeField] private GameObject adds;
    [SerializeField] private GameObject talents;
    [SerializeField] private GameObject settings;

    private bool impOn;
    private bool addOn;
    private bool talOn;
    private bool setOn;

    private void Update()
    {
        improvements.SetActive(impOn);
        adds.SetActive(addOn);
        talents.SetActive(talOn);
        settings.SetActive(setOn);
    }

    public void ImpOn()
    {
        impOn = true;
        addOn = false;
        talOn = false;
        setOn = false;
    }

    public void AddOn()
    {
        impOn = false;
        addOn = true;
        talOn = false;
        setOn = false;
    }

    public void TalOn()
    {
        impOn = false;
        addOn = false;
        talOn = true;
        setOn = false;
    }

    public void SetOn()
    {
        impOn = false;
        addOn = false;
        talOn = false;
        setOn = true;
    }
}
