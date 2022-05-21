using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraController : MonoBehaviour
{
    private CurveControlledBob headBob = new CurveControlledBob();

    // Start is called before the first frame update
    void Start()
    {
        headBob.Setup(Camera.main, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 handBob = headBob.DoHeadBob(0.5f);
        transform.localPosition = handBob;
    }
}
