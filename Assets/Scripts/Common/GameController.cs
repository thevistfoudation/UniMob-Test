using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : SingletonMono<GameController>
{
    public List<TableStuffController> tableStuff = new List<TableStuffController>();
    public TableCashController tablePurchaseStuff;
    public GameObject home;
    public Text moneyTxt;
    public float currentValueMoney;

    private void Start()
    {
        StartCoroutine(CreateClients());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            CreateClient();
        }
        moneyTxt.text = "Money" + currentValueMoney.ToString() + "$";
    }

    public void CreateClient()
    {
        var clientCanBuy = CreatController.instance.CreateClient(home.transform.position);
        var customerController = clientCanBuy.GetComponent<CustomerController>();
        customerController.characterState = CharacterState.GoTakeFruit;
        customerController.numberFruitNeedBuy = Random.Range(1, 4);
    }

    private IEnumerator CreateClients()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            CreateClient();
        }
       
    }

    public Vector3 TableStuffShortest()
    {
        return tableStuff[0].gameObject.transform.position;
    }
}
