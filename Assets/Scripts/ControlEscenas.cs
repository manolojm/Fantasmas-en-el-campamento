using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour {
    public void OnJugar() {
        SceneManager.LoadScene("DemoDay");
    }

    public void OnCreditos() {
        SceneManager.LoadScene("CreditosScene");
    }

    public void OnAyuda() {
        SceneManager.LoadScene("AyudaScene");
    }

    public void OnSalir() {
        Application.Quit();
    }

    public void OnMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
