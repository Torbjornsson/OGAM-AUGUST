using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogBehaviour : MonoBehaviour {

    private string basePath = "Graphics/UI/Dialog/";
    private string defImgPath = "defaultimage";
    public Sprite defImg;

    public GameObject dialogTextBackdrop;
    public Image dialogImage;
    public Text dialogImageText;
    public Text dialogText;

    private bool dialogActive = false;
    private GameObject currentSpeaker;

    void Update()
    {
        if (!defImg) { defImg = Resources.Load<Sprite>(basePath + defImgPath); }
    }

    public void SetDialog(Sprite speakerImg, string speakerName, string speakerText, GameObject speaker)
    {
        if (dialogActive) { print("another dialog already active"); return; }
        if (currentSpeaker && currentSpeaker != speaker) { return; }

        ToggleActive(true);
        if (!speakerImg) { print("defimg: " + defImg); dialogImage.sprite = defImg; }
        else { dialogImage.sprite = speakerImg; }
        dialogImageText.text = speakerName;
        dialogText.text = speakerText;
        currentSpeaker = speaker;
    }

    public void RemoveDialog(GameObject speaker)
    {
        if(!dialogActive) { print("no dialog to remove"); return; }
        if(speaker == currentSpeaker)
        {
            ToggleActive(false);
            currentSpeaker = null;
            dialogImage.sprite = defImg;
            dialogText.text = "...";
            dialogImageText.text = "...";
        }
        else
        {
            print("Someone else is trying to escape dialog: " + speaker.name);
        }
    }

    private void ToggleActive(bool b)
    {
        dialogActive = b;

        dialogImage.gameObject.SetActive(b);
        dialogTextBackdrop.gameObject.SetActive(b);

    }
}
