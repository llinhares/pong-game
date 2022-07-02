using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BtnColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;
    public PlayerBase myPlayer;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = color;
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }
}
