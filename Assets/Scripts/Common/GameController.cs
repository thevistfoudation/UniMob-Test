using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMono<GameController>
{
    public List<TableStuffController> tableStuff = new List<TableStuffController>();
    public GameObject tablePurchaseStuff;
    public GameObject home;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CreateClient();
        }
    }

    public void CreateClient()
    {
        var clientCanBuy = CreatController.instance.CreateClient(home.transform.position);
        var customerController = clientCanBuy.GetComponent<CustomerController>();
        customerController.characterState = CharacterState.GoTakeFruit;
        customerController.numberFruitNeedBuy = Random.Range(1, 4);
    }

    public Vector3 TableStuffShortest()
    {
        return tableStuff[0].gameObject.transform.position;
    }
}
