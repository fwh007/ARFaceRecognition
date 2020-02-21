using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapePicker : MonoBehaviour {

    public LipController lipController;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
            var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) {
                var gameObject = hit.collider.gameObject;
                if (gameObject.transform.parent == this.transform) {
                    var shape = gameObject.GetComponent<Shape> ().shape;
                    if (shape != null) {
                        lipController.SetShape (shape);
                    }
                }
            }
        }
    }
}