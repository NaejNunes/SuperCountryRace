using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public GameController gameController;

    private Transform[] checkpoints;

    private int maxCheckpoints = 0;
    private int checkpointAtual = 0;
    private int voltaAtual = 0;
    private int maximoVoltas;
    // Start is called before the first frame update

    private void Awake()
    {
        GameObject checkpointContainer = GameObject.FindGameObjectWithTag("CheckpointsContainer");

        checkpoints = new Transform[checkpointContainer.transform.childCount];

        for (int i = 0; i < checkpointContainer.transform.childCount; i++)
        {
            checkpoints[i] = checkpointContainer.transform.GetChild(i);
        }
    }
    void Start()
    {
        maximoVoltas = gameController.maximoVoltas;
        maxCheckpoints = checkpoints.Length - 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            if (other.transform == checkpoints[checkpointAtual])
            {
                if (checkpointAtual < maxCheckpoints)
                {
                    if (checkpointAtual == 0)
                    {
                        if (voltaAtual == maximoVoltas)
                        {
                            gameController.FinishRace(gameObject);
                        }
                        else
                        {
                            voltaAtual++;
                            gameController.UpdateVoltas(voltaAtual);
                        }
                    }
                    checkpointAtual++;
                }
                else {
                    checkpointAtual = 0;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
