using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
 private void OnTriggerEnter2D(Collider2D collision)

 {
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.GetComponent<Health1>().TakeDamage(3);
    }
 }

}
