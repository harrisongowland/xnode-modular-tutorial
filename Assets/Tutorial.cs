using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class Tutorial : MonoBehaviour
{

    public static Tutorial instance;
    private TutorialGraph currentGraph;

    private FirstPersonController controller; 

    [SerializeField]
    private bool armed = false;

    //UI stuff
    public Image headerImage;
    public Image inlayImage;
    public Image titleSection;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description; 

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            controller = FindObjectOfType<FirstPersonController>(); 
            return;
        }
        Destroy(this.gameObject);
    }

    public void ShowTutorial(TutorialGraph _graph)
    {
        currentGraph = _graph; 
        this.GetComponent<CanvasGroup>().alpha = 1f;
        controller.cameraCanMove = false;
        controller.playerCanMove = false; 
        armed = true;
    }

    public void HideTutorial()
    {
        this.GetComponent<CanvasGroup>().alpha = 0f;
        controller.cameraCanMove = true;
        controller.playerCanMove = true;
        armed = false;
    }

    public void ShowTutorialDetails(bool _showImage, bool _showText, bool _showDesc, Sprite _image, string _title, string _desc)
    {
        ResetHeaderAndTitleSections();
        if (_showImage)
        {
            headerImage.gameObject.SetActive(true);
            inlayImage.sprite = _image; 
        }
        if (_showText)
        {
            titleSection.gameObject.SetActive(true);
            title.text = _title;
            if (_showDesc)
            {
                description.text = _desc;
            }
        }
    }

    public void ResetHeaderAndTitleSections()
    {
        headerImage.gameObject.SetActive(false);
        titleSection.gameObject.SetActive(false);
    }

    public void Update()
    {
        bool enterPressedDuringTutorial = armed && Input.GetKeyDown(KeyCode.Return);

        if (enterPressedDuringTutorial)
        {
            //Enter pressed and tutorial is active
            Debug.Log("Enter pressed and tutorial is active");
            currentGraph.currentNode.NextNode("exit");
        }
    }
}
