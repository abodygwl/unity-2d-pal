using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    PlayerControls controls;
    float direction = 0;
    public Rigidbody2D PlayerRB;
    public float speed = 4f;
    public Animator animator;
    bool isFacingRight = true;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        
        {
          direction = ctx.ReadValue<float>();
        };
    }

    // Update is called once per frame
    void FixeUpdate()
    {
        PlayerRB.velocity = new Vector2(direction * speed , PlayerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if(isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }
        void  Flip()
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
