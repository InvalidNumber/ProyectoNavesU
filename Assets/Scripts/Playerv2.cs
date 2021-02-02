using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerv2 : MonoBehaviour
{
    public float speed;
    public float speedRot;

    public float shootForce;
    public GameObject bullet;
    public Transform[] shootPoint;
    byte cannonNumber = 0;

    public bool shootAll;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }


    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = 0.2f;
        else
            speed = 0.1f;


        //left es la flecha roja, y la verde up etc
        transform.Translate(Vector3.forward * speed * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * speed * Input.GetAxis("Horizontal"));
        transform.Translate(Vector3.up * speed * Input.GetAxis("UpDown"));
        
        transform.Rotate(Vector3.up * speedRot * Input.GetAxis("Mouse X"));
        transform.Rotate(Vector3.right * speedRot * Input.GetAxis("Mouse Y"));

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            shootAll = !shootAll;
        }
    }

    

    void Shoot()
    {
        if (shootAll)
        {
            for (int i = 0; i < shootPoint.Length; i++)
            {
                Destroy(Instantiate(bullet, shootPoint[i].position, shootPoint[i].rotation), 5);
            }
        }
        else
        {
            Destroy(Instantiate(bullet, shootPoint[cannonNumber].position, shootPoint[cannonNumber].rotation), 5);
            cannonNumber++;
            if (cannonNumber > 3)
                cannonNumber = 0;
        }
        
    }
}
