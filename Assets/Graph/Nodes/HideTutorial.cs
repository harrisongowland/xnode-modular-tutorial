using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class HideTutorial : BaseNode {


    public bool goOn; 

    public override void Execute()
    {
        Tutorial.instance.HideTutorial();
        if (goOn)
        {
            this.NextNode("exit");
        }
    }
}