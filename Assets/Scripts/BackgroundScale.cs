using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScale : MonoBehaviour
{
    private Image backgroundImage;
    private float ratioBackground;
    //position and size of a rectangle
    private RectTransform rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        //save the background image in variable
        backgroundImage = GetComponent<Image>();
        rectTransform = backgroundImage.rectTransform;
        //calculate ratio of the size
        ratioBackground = backgroundImage.sprite.bounds.size.x / backgroundImage.sprite.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!rectTransform)
            //???
           // return;

        //to fill the screen we need to adjust the ratio
        //we adjust according to hight, depending on the ratio
        if (Screen.height * ratioBackground >= Screen.width)
        {
            rectTransform.sizeDelta = new Vector2(Screen.height *ratioBackground, Screen.height);
        }
        else
        {
            rectTransform.sizeDelta = new Vector2(Screen.width, Screen.width / ratioBackground);
        }
    }
}
