using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCameraMove : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector3 PlayerPos = player.transform.position;
        transform.position = new Vector3(PlayerPos.x, transform.position.y, transform.position.z);
    }
}
