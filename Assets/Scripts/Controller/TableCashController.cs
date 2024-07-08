using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCashController : MonoBehaviour
{
    public GameObject boxCarton;
    public List<GameObject> listPosMoney = new List<GameObject>();
    public List<GameObject> listMoney = new List<GameObject>();
    public int currentMoney;

    public Vector3 posShow()
    {
        currentMoney += 1;
        if(currentMoney > listPosMoney.Count)
        {
            currentMoney = listPosMoney.Count;
        }
        var index = currentMoney - 1;
        return listPosMoney[index].transform.localPosition;
    }

    public void CreateAndSetMoney(int money)
    {
        for(int i = 0; i < money; i++)
        {
            listMoney.Add(CreatController.Instance.CreateMoney(posShow()));
        }
    }
}
