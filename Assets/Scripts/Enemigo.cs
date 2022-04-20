using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject _PuntosPrefab;

    public float _velEnem = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicioEnem = transform.position;
        posicioEnem = new Vector2(posicioEnem.x, posicioEnem.y - _velEnem * Time.deltaTime);
        transform.position = posicioEnem;

        Vector2 limitInferior = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < limitInferior.y)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ProjectilJugador")
        {
            Destroy(gameObject);
            GameObject punto = Instantiate(_PuntosPrefab);
            punto.transform.position = transform.position;

        }
    }

}
