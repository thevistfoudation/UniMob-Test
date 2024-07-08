using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatController : SingletonMono<CreatController>
{
    [SerializeField] private GameObject Tomamto;
    [SerializeField] private GameObject TreeTomato;
    [SerializeField] private GameObject TableTomamto;
    [SerializeField] private GameObject Client;

    public GameObject CreateTomamto(Vector3 pos)
    {
       var tomamto =  SmartPool.Instance.Spawn(Tomamto,pos, gameObject.transform.rotation);
       return tomamto; 
    }

    public GameObject CreateTreeTomato(Vector3 pos)
    {
        var treeTomamto = SmartPool.Instance.Spawn(TreeTomato, pos, Tomamto.transform.rotation);
        return treeTomamto;
    }

    public GameObject CreateTableTomamto(Vector3 pos)
    {
        var tableTomamto = SmartPool.Instance.Spawn(TableTomamto, pos, Tomamto.transform.rotation);
        return tableTomamto;
    }

    public GameObject CreateClient(Vector3 pos)
    {
        var clientObj = SmartPool.Instance.Spawn(Client, pos, Client.transform.rotation);
        return clientObj;
    }
}
