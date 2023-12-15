using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spwaner;
    [SerializeField]private float speed = 5f;
    Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;

    void Start()
    {
        transform.position = new Vector2(spwaner.transform.position.x,spwaner.transform.position.y + 0.5f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxis("Horizontal");
        float InputY = Input.GetAxis("Vertical");


        if (InputY > 0)
        {
            animator.SetBool("Up/Down", true);

        }
        if (InputY < 0)
        {
            animator.SetBool("Up/Down", false);

        }
        animator.SetFloat("SpeedUD", Mathf.Abs(InputY));


        if (InputX < 0)
        {
            animator.SetBool("Left/Right", true);

        }
        if (InputX > 0)
        {
            animator.SetBool("Left/Right", false);

        }
        animator.SetFloat("SpeedLR", Mathf.Abs(InputX));

        movement = new Vector2(speed * InputX, speed * InputY);



    }
    private void FixedUpdate()
    {
        rb.MovePosition( rb.position + movement * speed * Time.deltaTime);
    }
}
