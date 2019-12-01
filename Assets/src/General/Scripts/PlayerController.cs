using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Game
{

    protected float m_MoveX;
    protected Rigidbody2D m_rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    //protected Animator m_Anim;

    [Header("[Setting]")]
    public float moveSpeed = 6;
    public float jumpForce = 15;

    new protected void Start(){
        base.Start();
        if(OS.Contains("Android"))
            SetMobileControls();
        else
            DestroyMobileControls();
        
    }

    protected void SetMobileControls(){
        GameObject pointerR = GameObject.Find("PointerR"), pointerL = GameObject.Find("PointerL");
        Vector3 pointerPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/7, Screen.height/7));
        pointerR.transform.position = new Vector3(pointerPos.x + 0.7f, pointerR.transform.position.y, -0.5f);
        pointerL.transform.position = new Vector3(pointerPos.x - 0.7f, pointerL.transform.position.y, -0.5f);
    }

    protected void DestroyMobileControls(){ 
        GameObject pointerR = GameObject.Find("PointerR"), pointerL = GameObject.Find("PointerL");
        GameObject actionBtn = GameObject.Find("Action");
        Destroy(pointerR);
        Destroy(pointerL);
        Destroy(actionBtn);
    }

    protected void Flip(bool bLeft)
    {
        transform.localScale = new Vector3(bLeft ? 1 : -1, 1, 1);
    }


    protected void PerformJump()
    {

        m_rigidbody.velocity = new Vector2(0, 0);

        m_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

    }


    public void CheckInput(Action Callback)
    {
        if(OS.Contains("Android"))
        {
            if (Input.GetMouseButton (0)) {
                for (int i = 0; i < Input.touchCount; i++) {
                    Touch t = Input.GetTouch(i);
                    if (t.position.x < Screen.width/3 && t.position.x > Screen.width/7 && t.position.y < Screen.height/7) {
                        transform.position = new Vector2 (Mathf.Clamp (transform.position.x + 0.115f, -8.3f, 134), transform.position.y);
                        transform.rotation = new Quaternion (0, 0, 0, 0);
                        //animator.SetBool ("isMoving", true);
                    }
                    if (t.position.x < Screen.width/7 && t.position.y < Screen.height/7) {
                        transform.position = new Vector2 (Mathf.Clamp (transform.position.x - 0.115f, -8.3f, 134), transform.position.y);
                        transform.rotation = new Quaternion (0, 180, 0, 0);
                        //animator.SetBool ("isMoving", true);
                    }
                    if (t.position.x > 3 * Screen.width/4 && t.position.y < Screen.height/7) {
                        Callback();
                    }
                }
            }
        }

        else {
            m_MoveX = Input.GetAxis("Horizontal");
    

            if (Input.GetKey(KeyCode.Space))
            {
                Callback();
            }

            if (Input.GetKey(KeyCode.D))
            {   
                //StartCoroutine(SmallJump());

                transform.transform.Translate(new Vector3(m_MoveX * moveSpeed * Time.deltaTime, 0, 0));
                

                if (!Input.GetKey(KeyCode.A))
                    Flip(false);
            }

            else if (Input.GetKey(KeyCode.A))
            {

                //StartCoroutine(SmallJump());

                transform.transform.Translate(new Vector3(m_MoveX * moveSpeed * Time.deltaTime, 0, 0));

                

                if (!Input.GetKey(KeyCode.D))
                    Flip(true);

            }
        }

    }

    IEnumerator SmallJump(){
        m_rigidbody.AddForce(new Vector3(0, 40, 0));
        yield return new WaitForSeconds(0.1f);
        m_rigidbody.AddForce(new Vector3(0, -25, 0));
        yield return new WaitForSeconds(0.1f);
    }

    protected bool Near(Transform other){
        return Mathf.Abs(this.transform.position.x - other.position.x) < 2 &&
               Mathf.Abs(this.transform.position.y - other.position.y) < 3;
    }


}
