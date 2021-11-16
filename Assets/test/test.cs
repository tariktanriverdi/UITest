using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Camera camera;
    public float zax = 10;
    public GameObject ob1;
    public GameObject ob2;
    bool onTouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        MoveCube();
    }

    private void MoveCube()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Screen Width : " + Screen.width + "Screen height : " + Screen.height);
            // var mousePos = Input.mousePosition;
            // mousePos.z = zax;
            // Vector3 pos = camera.ScreenToWorldPoint(mousePos);


            // var val =Mathf.Atan( pos.y/ pos.x);
            // Debug.Log(Mathf.Rad2Deg*val);
            // //Debug.Log(pos);
            // if (pos.x < -1)
            // {
            //     transform.Translate(Vector3.left);
            // }
            // if (pos.x > 1)
            // {
            //     transform.Translate(Vector3.right);
            // }

        }

        if (Input.GetMouseButton(0))

        {
            // List<Vector3> vectors=new List<Vector3>();
            //   vectors=GetTouchVector(Camera.main);
            // Debug.DrawRay(vectors[0],vectors[1],Color.green);
            // RaycastHit hit;
            // if(Physics.Raycast(vectors[0],vectors[1],out hit)){
            //    //Destroy( hit.transform.gameObject);

            //  }
        }
        if (Input.GetMouseButton(0))
        {
            List<Vector3> vectors = new List<Vector3>();
            vectors = GetTouchVector(Camera.main);
            Debug.DrawRay(vectors[0], vectors[1], Color.green);
            RaycastHit hit;

            if (Physics.Raycast(vectors[0], vectors[1], out hit))
            {
                if (hit.transform.gameObject.CompareTag("Test"))
                {
                    onTouch = true;


                    //Destroy( hit.transform.gameObject);

                }


            }
            if (onTouch)
            {
                Debug.Log(onTouch);
                transform.position = vectors[2];
            }
        }
        if (!Input.GetMouseButton(0))
        {
            onTouch = false;
            Debug.Log(onTouch);
        }
       
    }
    public List<Vector3> GetTouchVector(Camera camera)
    {
        //Vector3 mousposFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.farClipPlane);
        Vector3 mousposFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - camera.transform.position.z);
        // Vector3 mousposNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 mousposNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 mouseF = camera.ScreenToWorldPoint(mousposFar);
        Vector3 mouseN = camera.ScreenToWorldPoint(mousposNear);
        //ob1.transform.position = mouseF;
        // ob2.transform.position = mouseN;
        List<Vector3> vectors = new List<Vector3>();
        vectors.Add(mouseN);
        vectors.Add(mouseF - mouseN);
        vectors.Add(mouseF);

        return vectors;
    }

     
}
