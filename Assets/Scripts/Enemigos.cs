using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private Transform _player2Follow;
    [SerializeField] private float _stopDistante, _speed;
    [SerializeField] private bool _variableSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _variableSpeed = true;
        if (_variableSpeed) {
            _speed = Random.Range(_speed / 3f, _speed * 1.8f);
        }
        if (_player2Follow == null) {
            _player2Follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player2Follow != null) {
            if (Vector3.Distance(transform.position, _player2Follow.position) > _stopDistante) {
                transform.position = Vector3.MoveTowards(transform.position, _player2Follow.position, _speed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Debug.Log("damagos");
        }
    }
}
