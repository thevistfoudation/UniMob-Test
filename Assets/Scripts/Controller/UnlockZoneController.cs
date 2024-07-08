using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockZoneController : MonoBehaviour
{
    public float price;
    public GameObject hiddenObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameController.Instance.currentValueMoney >= price)
            {
                GameController.Instance.currentValueMoney -= price;
                gameObject.SetActive(false);
                hiddenObject.SetActive(true);
            }
        }
    }
}