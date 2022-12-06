using UnityEngine;

public class Shopping : MonoBehaviour
{
    [SerializeField] GameObject shop;
    [SerializeField] GameObject closeShop;
    [SerializeField] GameObject swipeScanner;
    
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        shop.SetActive(isOpen);
        closeShop.SetActive(isOpen);
        swipeScanner.SetActive(!isOpen);
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
