using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public TextMeshProUGUI ammoText;
    //public TextMeshProUGUI vidasText;
    //Singleton

    public static GameManager instance {
        get; private set;
    }

    public int gunAmmo = 50;
    public int vidas = 10;
    public static int enemigosRestantes = 5;
    public static int numEnemigos = 0;

    private GameObject[] enemigos1, enemigos2, enemigos3;

    private void Awake() {
        instance = this;
    }

    void Update() {
        //ammoText.text = gunAmmo.ToString();
        //vidasText.text = vidas.ToString();

        if (enemigosRestantes < 1) {
            Debug.Log("Partida acabada!");

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

    public static void EnemigoDerrotado() {
        Debug.Log("enemigo menos");
        enemigosRestantes--;
    }

    public static void NuevoEnemigo() {
        numEnemigos++;
    }
}
