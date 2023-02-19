using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint; //punto de salida de la bala
    public GameObject bullet; // bala

    public float shotForce;  //fuerza disparo
    public float shotRate = 0.5f;  // tiempo hasta pr�xino disparo 
    private float shotRateTime = 0;  //tiempo desde que se dispar�

    // Sonido
    //public AudioClip shotSound;
    //private AudioSource shotSource;

    //public TextMeshProUGUI textAmmo;

    private void Start() {
        shotForce = 2000f;
    }

    private void Awake() {
        //shotSource = GetComponent<AudioSource>();

    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (Time.time > shotRateTime && GameManager.instance.gunAmmo > 0) {
                GameManager.instance.gunAmmo--;
                //textAmmo.text = GameManager.instance.gunAmmo.ToString();
                //shotSource.PlayOneShot(shotSound);
                GameObject newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * Time.deltaTime, ForceMode.Impulse);
                shotRateTime = Time.time + shotRate;
                Destroy(newBullet, 3);
            }
        }
    }
}
