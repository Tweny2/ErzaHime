using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ghost : Enemy
{
    private Rigidbody2D rb;
    private bool isFaceRight = true;
    private float leftx, rightx;

    //ghost�ƶ�λ��
    public float speed;
    public Transform leftPoint,rightPoint;
   
   
    new public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();//�ж�Ghost��������Ĺ�ϵ
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    new public void Update()
    {
        //���û���
        base.Update();
        Movement();
        
    }
    void Movement()
    {
        if (isFaceRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                isFaceRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x <leftx)
            {
                transform.localScale = new Vector3(1, 1, 1);
                isFaceRight = true;
            }
        
        }
    }


}
