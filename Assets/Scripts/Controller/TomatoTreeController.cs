using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoTreeController : MonoBehaviour
{
    [SerializeField] private float timeLoad;
    [SerializeField] private GameObject[] posCreateTomato;
    [HideInInspector]public List<GameObject> listTomato = new List<GameObject>();

    private void Awake()
    {
        this.RegisterListener(EventID.ReloadFruit, (sender, param) => StartCoroutine(CreateTomatoTree()));
    }

    private void Start()
    {
        StartCoroutine(CreateTomatoTree());
    }

    private IEnumerator CreateTomatoTree()
    {
        yield return new WaitForSeconds(0.5f);
        
        for (int i = 0; i < posCreateTomato.Length; i++)
        {
            var iCountFruit = listTomato.Count;
            if (iCountFruit < posCreateTomato.Length)
            {
                var tomamto = CreatController.Instance.CreateTomamto(posCreateTomato[i].transform.position);
                iCountFruit += 1;
                listTomato.Add(tomamto);
                yield return new WaitForSeconds(timeLoad);
            }
        }
    }

    public void DisableTomato(int numberReduce)
    {
        if(numberReduce >= listTomato.Count)
        {
            for (int i = 0; i < numberReduce; i++)
            {
                SmartPool.Instance.Despawn(listTomato[i]);
            }
            listTomato.Clear();
            StartCoroutine(CreateTomatoTree());
        }
        else
        {
            for (int i = 0; i < numberReduce; i++)
            {
                SmartPool.Instance.Despawn(listTomato[i]);
                listTomato.RemoveAt(i);
            }
            StartCoroutine(CreateTomatoTree());
        }
    }
}
