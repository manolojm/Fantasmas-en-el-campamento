using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public GameObject efectoExplosion;

    private void OnCollisionEnter(Collision collision) {

        //Instantiate(efectoExplosion, transform.position, transform.rotation);
        if (collision.gameObject.CompareTag("Enemigo1") || collision.gameObject.CompareTag("Enemigo2") 
            || collision.gameObject.CompareTag("Enemigo3")) {

            GameManager.EnemigoDerrotado();
            Destroy(collision.gameObject);
        }
    }
}
