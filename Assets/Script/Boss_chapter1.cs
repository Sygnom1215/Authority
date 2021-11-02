using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_chapter1 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject AttackObject1;
    [SerializeField]
    private GameObject AttackObject2;
    private bool isPattern1 = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(GameManager.Instance.time <= 55f && !isPattern1)
        {
            Pattern1();
        }
    }
    void Pattern1()
    {
        isPattern1 = true;
        AttackObject1.SetActive(true);
        AttackObject2.SetActive(true);
    }
}
