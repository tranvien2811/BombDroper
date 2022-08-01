using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControll : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public bool isTouch;

    private void OnEnable()
    {
        CustomClass.isBombDrag = 0;
    }

    void Update()
    {

        if (isTouch) 
        {
            if (Input.touchCount > 0 && CustomClass.isBombDrag == 0)
            {
                Touch touch = Input.GetTouch(0);

                // Handle finger movements based on TouchPhase
                switch (touch.phase)
                {
                    //When a touch has first been detected, change the message and record the starting position
                    case TouchPhase.Began:
                        // Record initial touch position.
                        GameManager.Instance.HitTarget.GetChild(0).gameObject.SetActive(true);
                        startPos = touch.position;
                        break;

                    //Determine if the touch is a moving touch
                    case TouchPhase.Moved:
                        // Determine direction by comparing the current touch position with the initial one
                        direction = touch.position - startPos;
                        actionTouch(touch.position);
                        break;

                    case TouchPhase.Ended:
                        if (CustomClass.isBombDrag == 0)
                        {
                            CustomClass.isBombDrag = 1;
                            actionTouch(touch.position);
                        }
                                               
                        // Report that the touch has ended when it ends
                        break;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                actionTouch(Input.mousePosition);
            }
        }             
    }

    private void actionTouch(Vector3 _pos)
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_pos);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == 9)
            {
                GameManager.Instance.HitTarget.position = hit.point;
                GameManager.Instance.airs.SetUpMoveAi(GameManager.Instance.HitTarget);
            }            
        }
    }
}
