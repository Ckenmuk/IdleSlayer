using UnityEngine;

public class Shopping : MonoBehaviour
{
    [SerializeField] GameObject shop;
    
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        shop.SetActive(isOpen);
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
