using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemigos : MonoBehaviour
{

    public GameObject[] enemigos;
    public float time;
    public float tiempoAleatorio;

    // Start is called before the first frame update
    void Start()
    {
        tiempoAleatorio = Random.Range(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        // Crear enemigo
        tiempoAleatorio -= Time.deltaTime;
        if (tiempoAleatorio <= 0) {
            CrearEnemigo();
            tiempoAleatorio = Random.Range(0, 10);
        }
    }

    public void CrearEnemigo() {
        Debug.Log("Nuevo enemigo");
        Vector3 posicionEnemigo = transform.position;

        var enemigoGenerado = enemigos[Random.Range(0, enemigos.Length)];
        var nuevoEnem = Instantiate(enemigoGenerado, posicionEnemigo, Quaternion.identity);
        nuevoEnem.SetActive(true);
        GameManager.NuevoEnemigo();
    }
}
