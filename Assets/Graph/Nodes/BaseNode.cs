using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {

	[Input] public int entry;
	[Output] public int exit;

	// Use this for initialization
	protected override void Init() {
		base.Init();
	}

	public virtual void Execute()
    {
		Debug.Log("Executing node");
		NextNode("exit");
    }

	public void NextNode(string _exit)
    {
		BaseNode b = null; 
		foreach (NodePort p in this.Ports)
        {
			if (p.fieldName == _exit)
            {
				//This is the one we're after
				b = p.Connection.node as BaseNode;
				break; 
            }
        }
		if (b != null)
        {
			TutorialGraph _graph = this.graph as TutorialGraph;
			_graph.currentNode = b;
			_graph.Execute(); 
        }
    }
}