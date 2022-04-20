using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauEnemiga2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _PuntosPrefab;
    private int _vidasNau = 3;
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
            _vidasNau--;
            if (_vidasNau == 0)
            {
                Destroy(gameObject);
                GameObject punto = Instantiate(_PuntosPrefab);
                punto.transform.position = transform.position;
            }

        }
    }


}
