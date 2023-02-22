using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PlayerInteraction : MonoBehaviour {
    public TextMeshProUGUI textAmmo;
    public Transform startPosition;

    private bool vulnerable = true;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Tienda")) {
            GameManager.instance.RecargarMunicion();
            textAmmo.text = GameManager.instance.gunAmmo.ToString();
            //Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Respawn")) {
            GameManager.instance.LoseHealth(2);
            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (vulnerable) {
            vulnerable = false;
            Debug.Log(vulnerable);
            if (collision.gameObject.CompareTag("Enemigo1")) {
                GameManager.instance.LoseHealth(1);
            }

            if (collision.gameObject.CompareTag("Enemigo2")) {
                GameManager.instance.LoseHealth(2);
            }

            if (collision.gameObject.CompareTag("Enemigo3")) {
                GameManager.instance.LoseHealth(3);
            }
            Invoke("HacerVulnerable", 2f);
        }
    }

    private void HacerVulnerable() {
        vulnerable = true;
    }
}
