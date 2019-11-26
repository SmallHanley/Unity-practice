using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerControl : MonoBehaviour {

    private float moveing_speed = 5f;
    private Rigidbody tr;
    private bool isGround;
    private int jumpTimes;
    public GameObject dirt;
    // Use this for initialization
    void Start () {
        tr = GetComponent<Rigidbody>();
        isGround = true;
        jumpTimes = 2;
        transform.localScale = new Vector3(2, 2, 2);
        //just kidding
        transform.position = new Vector3(5, 5, 5);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.forward * 2;
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.back * 2;
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.left * 2;
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * Vector3.right * 2;
        }
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * 100, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * 100, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            tr.AddForce(Vector3.up * 300);
            jumpTimes--;
            if(jumpTimes == 0)
            {
                isGround = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycashit;
            if (Physics.Raycast(ray, out raycashit))
            {
                if (raycashit.transform.tag == "cube")
                {
                    Destroy(raycashit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycashit;
            if (Physics.Raycast(ray, out raycashit))
            {
                GameObject cube = Instantiate(dirt);
                if (raycashit.collider.gameObject.tag == "ground" || raycashit.collider.gameObject.tag == "cube")
                {
                    cube.transform.tag = "cube";
                    float x = Mathf.Floor(raycashit.point.x) + cube.transform.localScale.x / 2;
                    float y = Mathf.Floor(raycashit.point.y) + cube.transform.localScale.y / 2;
                    float z = Mathf.Floor(raycashit.point.z) + cube.transform.localScale.z / 2;
                    cube.transform.position = new Vector3(x, y, z);
                }


            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground" || collision.gameObject.tag == "cube")
        {
            isGround = true;
            jumpTimes = 2;
        }
    }
}
