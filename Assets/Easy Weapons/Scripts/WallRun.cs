using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WallRun : MonoBehaviour
{
   private bool isWallRunR = false;
    private bool isWallRunL = false;
    private RaycastHit hitR;
    private RaycastHit hitL;
    private int jumpCount = 0;
    private RigidbodyFirstPersonController fpsRB;
    private Rigidbody rb; 
    public bool right = false;

    // Start is called before the first frame update
    void Start()
    {
        fpsRB = GetComponent<RigidbodyFirstPersonController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fpsRB.Grounded){
            jumpCount = 0;
        }
        //Input.GetKeyDown(KeyCode.E) && 
        if(Input.GetKeyDown(KeyCode.Space) && !fpsRB.Grounded && jumpCount <= 2)
        { 

            if(Physics.Raycast(transform.position,transform.right,out hitR, 1) || right)
            {
                if(hitR.transform.tag == "wall")
                {
                    Debug.Log("WallRun right");
                    isWallRunR = true;
                    isWallRunL = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                    right = false;
                }

            }
            
            if(Physics.Raycast(transform.position,-transform.right,out hitL, 1))
            {
                if(hitL.transform.tag == "wall")
                {
                    Debug.Log("WallRun left");
                    isWallRunL = true;
                    isWallRunR = false;
                    jumpCount += 1;
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                }

            }
        }
    }

    IEnumerator afterRun()
    {
        yield return new WaitForSeconds(1.0f);
        isWallRunL = false;
        isWallRunR = false;
        rb.useGravity = true;
    }

}
