using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu]
public class TutorialGraph : NodeGraph {

    public BaseNode startNode; 
	public BaseNode currentNode; 

    public void Start()
    {
        currentNode = startNode;
        Execute(); 
    }

	public void Execute()
    {
        currentNode.Execute(); 
    }
}