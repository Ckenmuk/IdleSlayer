using UnityEngine;

public class Shopping : MonoBehaviour
{
    [SerializeField] GameObject shop;
    //[SerializeField] GameObject exit;

    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        if (!isOpen)
        {
            shop.SetActive(false);
        }
        else
        {
            shop.SetActive(true);
        }
    }

    public void ShopIsOpen()
    {
        isOpen = true;
    }

    public void ShopIsClosed()
    {
        isOpen = false;
    }

}
