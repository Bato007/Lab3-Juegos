using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject wp;

    private NavMeshAgent agent;

    static int powerUp = 0;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        wp = gameObject;
        agent = GetComponent<NavMeshAgent>();
        score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo))
            {
                agent.SetDestination(hitInfo.point);
            }

        }


        if (score)
        {
            score.text = "Score: " + powerUp.ToString() + "/3";
        }
    }
          
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerUp != 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerUp++;
            Destroy(other.gameObject);
        }
            
    }
}
