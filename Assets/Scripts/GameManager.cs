using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI vidasText;
    public GameObject victoriaText;
    public GameObject ayudaText;
    public GameObject municionText;
    //Singleton

    public static GameManager instance {
        get; private set;
    }

    public int gunAmmo = 20;
    private int vidas = 10;
    private int enemigosRestantes = 10;
    private int numEnemigos = 0;

    private GameObject[] enemigos1, enemigos2, enemigos3;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        Invoke("OcultarAyuda", 7f);
    }

    void Update() {
        if (gunAmmo < 1) {
            MostrarMensajeMunicion();
        }

        if (vidas < 1) {
            vidas = 0;
        }

        ammoText.text = gunAmmo.ToString();
        vidasText.text = vidas.ToString();

        if (enemigosRestantes < 1) {
            victoriaText.SetActive(true);

            enemigos1 = GameObject.FindGameObjectsWithTag("Enemigo1");
            foreach (GameObject enemigo in enemigos1) {
                Destroy(enemigo);
            }

            enemigos2 = GameObject.FindGameObjectsWithTag("Enemigo2");
            foreach (GameObject enemigo in enemigos2) {
                Destroy(enemigo);
            }

            enemigos3 = GameObject.FindGameObjectsWithTag("Enemigo3");
            foreach (GameObject enemigo in enemigos3) {
                Destroy(enemigo);
            }
        }
    }

    public void LoseHealth(int heltToReduce) {
        vidas -= heltToReduce;
        if (vidas <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void EnemigoDerrotado() {
        Debug.Log("enemigo menos");
        instance.enemigosRestantes--;
    }

    public void NuevoEnemigo() {
        instance.numEnemigos++;
    }

    public void PerderVida() {
        instance.vidas--;
    }

    public void RecargarMunicion() {
        instance.gunAmmo = 20;
        municionText.SetActive(false);
    }

    public void OcultarAyuda() {
        ayudaText.SetActive(false);
    }

    public void MostrarMensajeMunicion() {
        municionText.SetActive(true);
    }
}
