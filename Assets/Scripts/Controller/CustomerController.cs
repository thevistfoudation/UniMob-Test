using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CustomerController : CharacterBehaviour
{
    public CharacterState characterState;
    public bool isReady;
    public int numberFruitNeedBuy;
    private bool isClaim;
    private bool isPayment;
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
        direction.Normalize();
        this.gameObject.transform.forward = direction;
        if (distance > 0.5f)
        {
           
            this.gameObject.transform.position += direction * Time.deltaTime * 5f;
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
        var posTablePurchase = GameController.Instance.home.gameObject.transform.position;
        MoveToDestination(posTablePurchase);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TableTomato") && !isClaim)
        {
            var tomatoTreeController = other.gameObject.GetComponent<TableStuffController>();
            var numberFruitCanClaim = tomatoTreeController.listTomato.Count;

            if (numberFruitCanClaim < numberFruitNeedBuy)
            {
                isMoving = false;
            }
            else
            {
                CreateTomamtoInArm(numberFruitNeedBuy);
                tomatoTreeController.DisableTomato(numberFruitNeedBuy);
                characterState = CharacterState.Gotopayment;
                isMoving = true;
                carrySomething = true;
                isClaim = true;
            }

        }
        else if (other.CompareTag("TablePayment") && !isPayment)
        {

            characterState = CharacterState.GoHome;
            var tableCashController = other.GetComponent<TableCashController>();
            var cartoonBox = CreatController.Instance.CreateBoxCarton();
            var pos = cartoonBox.transform.position;
            for (int i = 0; i < tomatoCarrying.Count; i++)
            {
                tomatoCarrying[i].transform.DOJump(pos, 2, 1, 1);
                tomatoCarrying[i].gameObject.SetActive(false);
                GameController.Instance.currentValueMoney += 1;
            }
            cartoonBox.transform.SetParent(posObjectCarrying.transform);
            cartoonBox.transform.position = posObjectCarrying.transform.position;
            characterState = CharacterState.GoHome;
            tableCashController.CreateAndSetMoney(5);
            carrySomething = true;
            isPayment = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("TableTomato") && !isClaim)
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
                carrySomething = true;
                isClaim = true;
            }
          
        }
        else if (other.CompareTag("TablePayment") && !isPayment)
        {
            characterState = CharacterState.GoHome;
            var tableCashController = other.GetComponent<TableCashController>();
            var cartoonBox = CreatController.Instance.CreateBoxCarton();
            var pos = cartoonBox.transform.position;
            for (int i = 0; i < tomatoCarrying.Count; i++)
            {
                tomatoCarrying[i].transform.DOJump(pos, 2, 1, 1);
                tomatoCarrying[i].gameObject.SetActive(false);
                GameController.Instance.currentValueMoney += 1;
            }
            cartoonBox.transform.SetParent(posObjectCarrying.transform);
            cartoonBox.transform.position = posObjectCarrying.transform.position;
            characterState = CharacterState.GoHome;
            tableCashController.CreateAndSetMoney(5);
            carrySomething = true;
            isPayment = true;
           
        }
    }
}
