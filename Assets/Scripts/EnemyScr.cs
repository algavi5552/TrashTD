using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();

    public GameObject wayPointsParent;

    int wayIndex = 0;
    int speed = 7;

    private void Start()
    {
        GetWaypoints();
       // wayPoints = GameObject.Find("Main Camera").GetComponent<GameControllerScr>().wayPoints;
    }

    void Update()
    {
        Move(); 
    }

    void GetWaypoints()
    {
        for (int i = 0; i < wayPointsParent.transform.childCount; i++)
            wayPoints.Add(wayPointsParent.transform.GetChild(i).gameObject);
    }
    private void Move()
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 0.1f)
        {
            if (wayIndex < wayPoints.Count - 1)
                wayIndex++;
            else
                Destroy(gameObject);
        } 
    }
}
