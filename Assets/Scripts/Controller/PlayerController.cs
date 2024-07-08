using DG.Tweening;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class PlayerController : CharacterBehaviour
{
    [SerializeField]
    private FloatingJoystick floatingJoystick;
    [SerializeField]
    private Animator animator;

    private void Update()
    {
        Handle();
    }

    private void Handle()
    {
        float horizontal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        if (horizontal != 0||vertical !=0)
        {
            Moving(direction);
            isMoving = true;
        }
        else if(horizontal == 0 && vertical == 0)
        {
            isMoving = false;
        }
        MovingAnim();
    }
    
    private  void Moving(Vector3 direction)
    {
        gameObject.transform.position += direction * Time.deltaTime * 10;
        this.gameObject.transform.forward = direction;
    }
    
    private void ReAddTomato()
    {
        if (posObjectCarrying.transform.childCount > 0)
        {
            carrySomething = true;
            for (int i = 0; i < posObjectCarrying.transform.childCount; i++)
            {
                currentCarrying += 1;
                tomatoCarrying.Add(posObjectCarrying.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            carrySomething = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TomatoTree"))
        {
            var tomatoTreeController = other.gameObject.gameObject.GetComponent<TomatoTreeController>();
            var numberFruitCanClaim = tomatoTreeController.listTomato.Count;

            if (numberFruitCanClaim >= maxCarrying - currentCarrying)
            {
                CreateTomamtoInArm(maxCarrying - currentCarrying);
                tomatoTreeController.DisableTomato(maxCarrying - currentCarrying);
            }
            else
            {
                CreateTomamtoInArm(numberFruitCanClaim);
                tomatoTreeController.DisableTomato(numberFruitCanClaim);
            }

        }
        if (other.gameObject.CompareTag("TableTomato"))
        {
            var tableStuffController = other.gameObject.gameObject.GetComponent<TableStuffController>();
            for (int i = 0; i < tomatoCarrying.Count; i++)
            {
                if (tableStuffController.CanGetFruit())
                {
                    currentCarrying -= 1;
                    var pos = tableStuffController.posShow(tomatoCarrying[i]);
                    tomatoCarrying[i].transform.DOJump(pos, 2, 1, 1);
                    tomatoCarrying[i].transform.parent = null;
                    //tomatoCarrying.Remove(tomatoCarrying[i]);
                }
            }
            tomatoCarrying.Clear();
            ReAddTomato();

            if (currentCarrying <= 0)
            {
                carrySomething = false;
            }
        }
    }
}
