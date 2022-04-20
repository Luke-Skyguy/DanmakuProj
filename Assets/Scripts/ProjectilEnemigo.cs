using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnemigo : MonoBehaviour
{

    private float _velProjectilEnemigo;
    private bool _projectilAPunt;
    private Vector2 _direcionProjectil;
    // Start is called before the first frame update
    void Awake()
    {
        _velProjectilEnemigo = 10f;
        _projectilAPunt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_projectilAPunt)
        {
            Vector2 novaPos = transform.position;
            novaPos += _direcionProjectil * _velProjectilEnemigo * Time.deltaTime;
            transform.position = novaPos;
        }
        Vector2 limitInferior = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < limitInferior.y)
        {
            Destroy(gameObject);
        }

    }

    public void setDireccio(Vector2 direccio)
    {
        _direcionProjectil = direccio.normalized;
        _projectilAPunt = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NauJugador")
        {
            Destroy(gameObject);
        }
    }
}
