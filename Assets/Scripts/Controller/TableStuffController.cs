using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStuffController : MonoBehaviour
{
    public bool hasFruit;
    public List<GameObject> posList = new List<GameObject>();
    public List<GameObject> listTomato = new List<GameObject>();
    public int currentFruit;

    public Vector3 posShow(GameObject obj)
    {
        currentFruit += 1;
        listTomato.Add(obj);
        hasFruit = true;
        obj.transform.SetParent(transform);
        var index = currentFruit - 1;
        return posList[index].transform.position;
    }

    public bool CanGetFruit()
    {
        if(currentFruit < posList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DisableTomato(int numberReduce)
    {
        if (numberReduce >= listTomato.Count)
        {
            for (int i = 0; i < numberReduce; i++)
            {
                SmartPool.Instance.Despawn(listTomato[i]);
            }
            listTomato.Clear();
            hasFruit = false;
        }
        else
        {
            for (int i = 0; i < numberReduce; i++)
            {
                SmartPool.Instance.Despawn(listTomato[i]);
                listTomato.RemoveAt(i);
            }
        }
    }
}
