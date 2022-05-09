using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offSet;

    private void Start()
    {
        Player = GameObject.Find("Player");
        offSet = new Vector3(0, 0, -10f);
    }
    private void LateUpdate()
    {
        transform.position = Player.transform.position + offSet;
    }
}
