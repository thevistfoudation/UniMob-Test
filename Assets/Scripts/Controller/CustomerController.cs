using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomerController : CharacterBehaviour
{
    public CharacterState characterState;
    public bool isReady;
    public int numberFruitNeedBuy;

    private void OnEnable()
    {
        characterState = CharacterState.GoTakeFruit;
    }

    private void Update()
    {
        if (characterState == CharacterState.Gotopayment)
        {
            GoToPurchaseStuff();
        }
        else if(characterState == CharacterState.GoTakeFruit)
        {
            ClaimStuff();
        }
        else if (characterState == CharacterState.GoHome)
        {
            GotoHome();
        }
    }

    private void MoveToDestination(Vector3 pos)
    {
        var distance = Vector3.Distance(pos, this.gameObject.transform.position);
        var direction = pos - this.gameObject.transform.position;
        this.gameObject.transform.right = direction;
        if (distance > 0.5f)
        {
            this.gameObject.transform.position += direction * Time.deltaTime * 0.5f;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        MovingAnim();
    }

    private void ClaimStuff()
    {
        var posDestination = GameController.Instance.TableStuffShortest();
        MoveToDestination(posDestination);
    }

    private void GoToPurchaseStuff()
    {
        var posTablePurchase = GameController.Instance.tablePurchaseStuff.gameObject.transform.position;
        MoveToDestination(posTablePurchase);
    }

    private void GotoHome()
    {
        var posTablePurchase = GameController.Instance.tablePurchaseStuff.gameObject.transform.position;
        MoveToDestination(posTablePurchase);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("TableTomato"))
        {
            var tomatoTreeController = other.gameObject.GetComponent<TableStuffController>();
            var numberFruitCanClaim = tomatoTreeController.listTomato.Count;

            if(numberFruitCanClaim < numberFruitNeedBuy)
            {
                isMoving = false;
            }
            else
            {
                CreateTomamtoInArm(numberFruitNeedBuy);
                tomatoTreeController.DisableTomato(numberFruitNeedBuy);
                characterState = CharacterState.Gotopayment;
                isMoving = true;
            }
          
        }
        else if (other.CompareTag("TablePayment"))
        {
            characterState = CharacterState.GoHome;
        }
    }
}
