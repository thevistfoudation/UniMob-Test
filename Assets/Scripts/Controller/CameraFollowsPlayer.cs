using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 11, -15);
    }
}
