using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
public class RunGraph : MonoBehaviour
{

    public NodeGraph graph;
    public bool playOnce = false;
    private bool played = false; 

    private void OnTriggerEnter(Collider other)
    {
        bool notAlreadyPlayed = (playOnce == false || playOnce == true && played == false);

        if (other.gameObject.tag == "Player" && notAlreadyPlayed)
        {
            played = true; 
            Debug.Log("Player collided with volume");
            TutorialGraph _graph = graph as TutorialGraph;
            _graph.Start();
        }
    }
}
