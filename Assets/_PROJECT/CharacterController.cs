using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    float speed;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float hor_ = Input.GetAxis("Horizontal");
        float ver_ = Input.GetAxis("Vertical");
        
        
        if (hor_ == 0f && ver_ == 0f)
        {
            speed = 0f;
            animator.SetFloat("speed", speed);
        }
        else
        {
            speed = 3f;
            animator.SetFloat("speed", speed);
        }

        transform.position += new Vector3(hor_, 0f, ver_) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("attack");
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    speed = 1f;
        //    animator.SetFloat("speed", speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.I))
        //{
        //    speed = 0f;
        //    animator.SetFloat("speed", speed);
        //}
        //else if (Input.GetKeyDown(KeyCode.A))
        //{
        //    speed = 1f;
        //    animator.SetTrigger("attack");
        //}
    }
}
