using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PolygonCollider2D pgCollider;

    public int damage;
    public float endTime;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        pgCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        Attack();
    }
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            pgCollider.enabled = true;
            anim.SetTrigger("attacking");
            StartCoroutine(disableHitBox());
        }
    }
    IEnumerator disableHitBox()//Ð­³Ì
    {
        yield return new WaitForSeconds(endTime);
        pgCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy_Ghost>().TakeDamage(damage);
            
        }
        
    }
}
*/