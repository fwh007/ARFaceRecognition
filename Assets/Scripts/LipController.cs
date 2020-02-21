using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LipController : MonoBehaviour {

    private readonly int UPDATE_COUNT = 40000;

    public Texture2D shape;
    public Color color;

    private int shapeWidth, shapeHeight;
    // private Texture2D newTexture;

    public void SetShape (Texture2D newShape) {
        shape = newShape;
        StartCoroutine (updateTexture ());
    }

    public void SetColor (Color newColor) {
        color = newColor;
        StartCoroutine (updateTexture ());
    }

    private int updateCounter = 0;

    public IEnumerator updateTexture () {
        if (shape == null || color == null) yield break;
        Debug.Log ("LipController -> updateTexture: Start");
        shapeWidth = shape.width;
        shapeHeight = shape.height;
        var newTexture = new Texture2D (shapeWidth, shapeHeight, TextureFormat.ARGB32, false);
        Debug.Log ("LipController -> updateTexture: Init");
        for (int x = 0; x < shapeWidth; x++) {
            for (int y = 0; y < shapeHeight; y++) {
                var pixelColor = color * shape.GetPixel (x, y).a;
                newTexture.SetPixel (x, y, pixelColor);
                if ((++updateCounter) > UPDATE_COUNT) {
                    Debug.Log ("LipController -> updateTexture: Start Yield");
                    updateCounter = 0;
                    yield return 0;
                    Debug.Log ("LipController -> updateTexture: End Yield");
                }
            }
        }
        Debug.Log ("LipController -> updateTexture: Apply");
        newTexture.Apply (false);
        Debug.Log ("LipController -> Update");
        var material = GetComponent<Renderer> ().material;
        material.mainTexture = newTexture;
        // material.shader = Shader.Find ("Unlit/Transparent");
        Debug.Log ("LipController -> Update: Finish");
    }

    void Awake () {
        // StartCoroutine (updateTexture ());
    }

    void Update () { }
}