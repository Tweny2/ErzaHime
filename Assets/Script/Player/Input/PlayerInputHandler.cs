/*
ErzaHime_v0.01
    Version Target:
        1.Input system:移动、跳跃、攻击
        
       
        
        



*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D feet;
    private bool isGround;
    private bool isVolley;//凌空的时候
    


    public float speed;
    public float jumpForce;
    public float doubleJumpForce;
   









    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        feet = GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        Run();
        Turn();
        Jump();
        CheckGround();
        AnimSwitch();






    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDir * speed, rb.velocity.y);

        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon; //Epsilon是一个无穷小，趋于0的正数
        anim.SetBool("running", playerHasXAxisSpeed);//当横轴有速度时，running为true

    }
    void Turn()
    {
        float faceDir = Input.GetAxisRaw("Horizontal");//利用AxisRaw的三个值-1，0，1，实现转向
        if (faceDir != 0)
        {
            transform.localScale = new Vector3(faceDir, 1, 1);
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                anim.SetBool("jumping", true);
                rb.velocity = new Vector2(0.0f, jumpForce);
                isVolley = true;
            }
            else
            {
                if (isVolley)
                {
                    anim.SetBool("doubleJump", true);
                    rb.velocity = new Vector2(0.0f, doubleJumpForce);
                    isVolley = false;//关闭凌空状态
                }
            }
          
            
        }
    }
    void CheckGround()
    {
        isGround = feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    void AnimSwitch()
    {
        if (anim.GetBool("jumping"))
        {
            if (rb.velocity.y < 0.0f)//when y轴速度小于0，从跳跃动画切换到下落动画
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if (isGround)
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
        //二段跳动画切换
        if (anim.GetBool("doubleJump"))
        {
            if (rb.velocity.y < 0.0f)
            {
                anim.SetBool("doubleJump", false);
                anim.SetBool("doubleFall", true);
            }
        }
        else if (isGround)
        {
            anim.SetBool("doubleFall", false);
            anim.SetBool("idle", true);
        }


    }









}
