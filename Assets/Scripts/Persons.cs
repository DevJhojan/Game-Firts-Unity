using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persons : MonoBehaviour
{
    #region variables
    Transform cam;
    CharacterController control;
    private Animator anim;
    public float speedCam = 110.5f;
    public float speedMoving = 8.0f;
    public float speedRotation = 90.6f;
    public float camRotation=0f;
    public float x, y, mx, my;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cam = transform.GetChild(0).GetComponent<Transform>(); 
        control= GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        #region Axis
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        mx = Input.GetAxis("Mouse X");
        my = Input.GetAxis("Mouse Y");
        #endregion

        #region Transforms
        transform.Rotate(new Vector3(0, mx, 0) * speedCam * Time.deltaTime);
        transform.Rotate(0, x * Time.deltaTime * speedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speedMoving);
        #endregion

        #region Animator
        anim.SetFloat("spX", x);
        anim.SetFloat("spY", y);
        #endregion

        #region Cam
        camRotation -= my * speedCam * Time.deltaTime;
        camRotation = Mathf.Clamp(camRotation, -90, 90);
        cam.localRotation = Quaternion.Euler(new Vector3(camRotation, 0, 0));
        #endregion
    }
}
