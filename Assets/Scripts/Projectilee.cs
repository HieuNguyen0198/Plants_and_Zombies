﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilee : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        //health.DealDamage(damage);
        var attacker = otherCollider.GetComponent<Attacker>();
        if(attacker && health)
        {
            health.DealDamage(damage);

            //lam cham hay stun o cho nay
            //attacker.SetStun();
            //attacker.SetSlowMomentSpeed();

            //khoi phuc o cho nay

      
           
          
            //huy vu khi
            Destroy(gameObject);
        }
    }
 
}
