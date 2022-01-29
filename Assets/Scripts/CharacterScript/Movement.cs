using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] int velocidad = 5;
    [SerializeField] float poderJugador = 10;
    [SerializeField] float vida = 100;
    [SerializeField] float cantVida = 5;
    [SerializeField] Vector3 direccion;
    [SerializeField] bool lePegue = false;
    // Start is called before the first frame update
    void Start()
    {
        PosicionInicial();
        CurarJugador();
        Debug.Log("La vida del jugador curado es " + vida.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (!lePegue)
        {
            PegarleAJugador();
            Debug.Log("Ahora le pegué y quedó con " + vida.ToString());
            lePegue = true;
        }
        Move(direccion);

        if(vida <= 0f)
        {
            Debug.Log("GAME OVER");
            UnityEditor.EditorApplication.isPlaying = false;
        }
            
        /*if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            CurarJugador();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            CurarJugador();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            PegarleAJugador();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            PegarleAJugador();
        }*/
    }

    void Move(Vector3 moverseA)
    {
        transform.Translate(moverseA * velocidad * Time.deltaTime);
    }

    void PosicionInicial()
    {
        transform.Translate(new Vector3(0, 0, 0));
    }

    void CurarJugador()
    {
        vida += cantVida;
    }

    void PegarleAJugador()
    {
        vida -= cantVida * 0.5f;
    }

}
