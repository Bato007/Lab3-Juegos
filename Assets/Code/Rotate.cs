using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rotate : MonoBehaviour
{

    public GameObject wp;
    private List<GameObject> listWp;

    private NavMeshAgent agent;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        listWp = new List<GameObject>();

        for(int i = 0; i < wp.transform.childCount; i++)
        {
            listWp.Add(wp.transform.GetChild(i).gameObject);
        }

        agent.SetDestination(listWp[Random.Range(0, listWp.Count - 1)].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(agent.remainingDistance < 1f)
        {
            agent.SetDestination(listWp[Random.Range(0, listWp.Count - 1)].transform.position);
        }

    }
}
