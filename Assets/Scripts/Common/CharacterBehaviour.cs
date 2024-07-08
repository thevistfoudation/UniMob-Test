using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterBehaviour : MonoBehaviour
{
    public GameObject posObjectCarrying;
    public bool carrySomething;
    public int currentCarrying;
    public int maxCarrying;

    [SerializeField]
    private Animator animator;
    [HideInInspector]
    public bool isMoving;
    public List<GameObject> tomatoCarrying = new List<GameObject>();
    
    public virtual void CreateTomamtoInArm(int numberTomato)
    {
        carrySomething = true;
        for (int i = 0; i < numberTomato; i++)
        {
            var tomato = CreatController.Instance.CreateTomamto(posObjectCarrying.transform.position + new Vector3(0, currentCarrying / 2f, 0));
            tomato.transform.SetParent(posObjectCarrying.transform);
            tomatoCarrying.Add(tomato);
            currentCarrying += 1;
        }
    }

    public virtual void MovingAnim()
    {
        if (isMoving)
        {
            SetAnimMove();
        }
        else
        {
            SetAnimIdle();
        }
    }
    
    private void SetAnimIdle()
    {
        if (carrySomething)
        {
            animator.Play("CarryIdle");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void SetAnimMove()
    {
        if (carrySomething)
        {
            animator.Play("CarryMove");
        }
        else
        {
            animator.Play("Move");
        }
    }
}
