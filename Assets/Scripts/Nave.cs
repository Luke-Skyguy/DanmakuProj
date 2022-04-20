using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nave : MonoBehaviour
{
    public float _velNau = 0.1f;
    private bool _reducido = false;
    public GameObject _posicioCano1;
    public GameObject _posicioCano2;
    public GameObject _projectilPrefab;
    public GameObject _explosioPrefab;
    public GameObject _gameManager;
    private int _vidasNau = 3;
    
    private int _puntos;
    public AudioSource _sonidoLaser;
    public Text textVida;
 public Text textPuntos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoureNau();
        ReduccionVelocidad();
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

    }
    private void ReduccionVelocidad()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!_reducido)
            {
                _velNau = _velNau / 2;
                _reducido = !_reducido;
            }
            else
            {
                _velNau = _velNau * 2;
                _reducido = !_reducido;
            }
        }

    }
    public void Disparar()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("entra espai");
            GameObject projectil1 = Instantiate(_projectilPrefab);
            projectil1.transform.position = _posicioCano1.transform.position;

            GameObject projectil2 = Instantiate(_projectilPrefab);
            projectil2.transform.position = _posicioCano2.transform.position;

            _sonidoLaser.Play();
        }
    }
    public void reiniciarVidas()
    {
        _vidasNau = 3;
        textVida.text = _vidasNau.ToString();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Puntos")
        {
            _puntos+=300;
            textPuntos.text = "Puntos: "+_puntos.ToString();

        }
       
        if (_vidasNau < 3)
        {
            if (other.tag == "Vidas")
            {
                _vidasNau++;
                textVida.text = _vidasNau.ToString();
            }
        }
        if (other.tag == "ProjectilEnemic")
        {
            _vidasNau--;
            textVida.text = _vidasNau.ToString();

            if (_vidasNau == 0)
            {
                gameObject.SetActive(false);
                GameObject explosio = Instantiate(_explosioPrefab);
                explosio.transform.position = transform.position;

                //_gameManager.SetEstadoGameOver();
            }
        }
    }


}
