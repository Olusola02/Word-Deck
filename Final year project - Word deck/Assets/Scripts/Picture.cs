using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class Picture : MonoBehaviour
{
    private Material Letter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SetLetters(Material mat, string texturePath)
    {
       Letter = mat;
       Letter.mainTexture = resources.load(texturePath, typeof(Texture2D)) as Texture2D;
    }

    public void ApplyLetter()
    {
        gameObject.GetComponent<Renderer>().material = Letter;
    }
}
