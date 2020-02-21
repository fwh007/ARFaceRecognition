using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {
        Debug.Log ("StartI -> Call");
        StartCoroutine (StartI ());
    }

    // Update is called once per frame
    void Update () {
        Debug.Log ("UpdateI -> Call");
        // StartCoroutine (UpdateI ());
    }

    private int startCounter = 0;

    private IEnumerator StartI () {
        Debug.Log ("StartI -> 0 " + (++startCounter));
        yield return 0;
        Debug.Log ("StartI -> 1 " + (++startCounter));
        yield return 1;
        Debug.Log ("StartI -> 2 " + (++startCounter));
        yield return 2;
        Debug.Log ("StartI -> 3 " + (++startCounter));
        yield return 3;
        Debug.Log ("StartI -> End");
    }

    private int updateCounter = 0;

    private IEnumerator UpdateI () {
        Debug.Log ("UpdateI -> " + (++updateCounter));
        yield return 0;
        Debug.Log ("UpdateI -> End");
    }
}