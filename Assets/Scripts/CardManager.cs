using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Sprite[] sprites;
    private int random;
    public Image image;

    public void Start()
    {
        random= Random.Range(0,sprites.Length);
        image.sprite=sprites[random];
    }
    public void Update()
    {
       
    }
}
