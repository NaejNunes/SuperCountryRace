using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] players;
    public Text hudPrincipal, hudVoltas;
    public int voltaAtual = 0, maximoVoltas = 5;

    private float timer, delay = 1f;

    private int contador = 4;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;

        foreach (GameObject m_gameObject in players)
        {
            m_gameObject.GetComponent<PlayerController>().enabled = false;
        }

        hudVoltas.text = string.Format("{0}/{1}", voltaAtual, maximoVoltas);
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > 0)
        {
            if (delay < (Time.time - timer))
            {
                timer = Time.time;
                contador--;
            }

            switch (contador)
            {
                case 4:
                    hudPrincipal.text = "Super Country Race";
                    break;
                case 3:
                    hudPrincipal.text = "READY!";
                    break;
                case 2:
                    hudPrincipal.text = "SET!";
                    break;
                case 1:
                    hudPrincipal.text = "GO!";
                    foreach (GameObject m_gameObject in players)
                    {
                        m_gameObject.GetComponent<PlayerController>().enabled = true;
                    }
                    break;

                case 0:
                    hudPrincipal.text = "";
                    break;

                default:
                    break;
            }          
        }
    }

    public void UpdateVoltas(int voltaPlayer)
    {
        if (voltaPlayer > voltaAtual)
        {
            voltaAtual = voltaPlayer;
            hudVoltas.text = string.Format("{0}/{1}", voltaAtual, maximoVoltas);
        }
    }

    public void FinishRace(GameObject winner)
    {
        foreach (GameObject m_gameObject in players)
        {
            if (m_gameObject == winner)
            {
                m_gameObject.GetComponent<PlayerController>().enabled = false;
            }
            else {
                m_gameObject.SetActive(false);
            }
        }
        hudPrincipal.text = string.Format("Player {0} ganhou!!!", winner.GetComponent<PlayerController>().playerID);
    }
}
