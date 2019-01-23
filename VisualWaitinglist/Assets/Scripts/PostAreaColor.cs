using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAreaColor : MonoBehaviour
{
    private Renderer ColorRenderer;
    [SerializeField]
    private Color ActualColor;

    void Start()
    {
        ColorRenderer = GetComponent<Renderer>();
        SetRandomColor();
    }

    public void SetRandomColor()
    {
        ColorRenderer.material.color = UnityEngine.Random.ColorHSV();
        ActualColor = ColorRenderer.material.color;
    }

}
