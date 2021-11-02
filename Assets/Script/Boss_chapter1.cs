using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_chapter1 : MonoBehaviour
{
    [SerializeField]
    private Player player = null;
    [SerializeField]
    private Transform bossPositionn = null;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject AttackObject1;
    [SerializeField]
    private GameObject AttackObject2;
    private bool isPattern1 = false;
    private LineRenderer lineRenderer = null;
    private bool isStop = true;
    private bool isPattern2 = false;
    Vector2 rot = Vector2.zero;

    Coroutine pattern2;
    void Start()
    { 
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (!isStop)
        {
            SeaPlayer();
        }
        if (GameManager.Instance.time <= 59f && !isPattern2)
        {
            Pattern2();
        }
        if (GameManager.Instance.time <= 55f && !isPattern1)
        {
            Pattern1();
        }
        if (Vector2.Distance(player.transform.position, transform.position) <= .5f)
        {
            Player.Instance.StartHit();
        }
        void Pattern1()
        {
            isPattern1 = true;
            AttackObject1.SetActive(true);
            AttackObject2.SetActive(true);
        }
        void SeaPlayer()
        {
            rot = player.transform.position - bossPositionn.position;
            var angle = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
            //bossPositionn.rotation = Quaternion.Euler(0, 0, angle);
            //Angle = angle + 90;
            lineRenderer.SetPosition(0, bossPositionn.position);
            if (angle < 0)
            {
                angle += 270;
            }
            lineRenderer.SetPosition(1, angle * player.transform.position);
        }
        void Pattern2()
        {
            isPattern2 = true;
            isStop = false;
            pattern2 = StartCoroutine(RushToTarget());
        }

        IEnumerator RushToTarget()
        {
            for (int i = 0; i < 3; i++)
            {
                lineRenderer.enabled = true;
                yield return new WaitForSeconds(0.2f);
                lineRenderer.enabled = false;
                yield return new WaitForSeconds(0.2f);
            }
            Vector2 target = player.transform.position;
            yield return new WaitForSeconds(0.1f);
            isStop = true;
            while (transform.position.x != target.x && transform.position.y != target.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, 0.1f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }
    }
}
