using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float _velNau = 0.1f;
    public GameObject _posicioCano1;
    public GameObject _posicioCano2;
    public GameObject _projectilPrefab;
    private int _vidasNau=5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();

        Disparar();
    }

    private void MoureNau()
    {

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;
        Vector2 novaPosNau = transform.position;
        novaPosNau += direccioIndicada * _velNau;

        minPantalla.x += 0.5f;
        minPantalla.y += 0.5f;
        maxPantalla.x += 0.5f;
        maxPantalla.y += 0.5f;

        novaPosNau.x = Mathf.Clamp(novaPosNau.x, minPantalla.x, maxPantalla.x);
        novaPosNau.y = Mathf.Clamp(novaPosNau.y, minPantalla.y, maxPantalla.y);


        transform.position = novaPosNau;

        Debug.Log(direccioIndicadaX);
    }
    public void Disparar()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil1 = Instantiate(_projectilPrefab);
            projectil1.transform.position = _posicioCano1.transform.position;

            GameObject projectil2 = Instantiate(_projectilPrefab);
            projectil2.transform.position = _posicioCano2.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);

        if (other.tag == "ProjectilEnemic")
        {
            _vidasNau--;

            if(_vidasNau<=0){
                gameObject.SetActive(false) ;
            }
        }
    }
}
