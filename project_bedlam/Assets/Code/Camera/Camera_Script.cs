using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Camera_Script : MonoBehaviour
{
    public GameObject tactical_camera;
    public GameObject MainCamera;
    public bool Switch = false;
    public KeyCode CameraKey;

    public float CameraSpeed = 10;
    public float rotationSpeed = 10;
    private float zoom;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    
    void Update()
    {

        
            CameraMove();

        //Zoom
       if (Input.GetAxis("Mouse ScrollWheel") > 0) //In
        {
            GetComponent<Camera>();
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y- 0.3f, transform.position.z + 0.1f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //Out
        {
            GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z -0.1f);
        }
        if (Input.GetKeyDown(CameraKey))
        {
            
            if (Switch == true)
            {
                Debug.Log("dd");
                Display_tactical_cam();
            }
            else
            {
                Display_main_cam();
            }
            
        }
        //Rotate



    }
    
    public void Display_tactical_cam ()
    {
        Switch = false;
        tactical_camera.SetActive(true);
        //MainCamera.SetActive(false);
        
        
        
    }
    public void Display_main_cam()
    {
        Switch = true;
        //MainCamera.SetActive(true);
        tactical_camera.SetActive(false);
    }
    void CameraMove()
    {
        
            if (Input.GetKey(KeyCode.W))
            {
                transform.localPosition += Vector3.forward * CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))

            {
                
                transform.localPosition += Vector3.left * CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))

            {
              
                transform.localPosition += Vector3.right * CameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.localPosition += Vector3.back * CameraSpeed * Time.deltaTime;
            }
        
        
    }
}
