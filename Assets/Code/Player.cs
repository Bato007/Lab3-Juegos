using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float force = 2f;
    public float jumpForce = 5f;
    
    public Rigidbody rgb;
    int powerUp = 0;

    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody>();

        score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rgb && Input.GetButtonDown("Jump") && (Time.timeScale > 0.0f))
        {
            Jump(); 
        }

        if (score)
        {
            score.text = "Score: " + powerUp.ToString() + "/3";
        }
    }
    private void FixedUpdate()
    {
        if (rgb)
        {
            rgb.AddForce(Input.GetAxis("Horizontal") * force, 0,
                Input.GetAxis("Vertical") * force);
        }
    }
    private void Jump()
    {
        if (Mathf.Abs(rgb.velocity.y) < 0.05f)
            rgb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && powerUp != 3)
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
