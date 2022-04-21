using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DisplayTutorial : BaseNode {

    public bool showImage = false;
    public bool showText = false;
    public bool showDesc = false; 

    public Sprite imageSprite; 

    public string titleText;
    public string descriptionText; 

    public override void Execute()
    {
        Tutorial.instance.ShowTutorial(this.graph as TutorialGraph);
        Tutorial.instance.ShowTutorialDetails(showImage, showText, showDesc, imageSprite, titleText, descriptionText);
    }

}