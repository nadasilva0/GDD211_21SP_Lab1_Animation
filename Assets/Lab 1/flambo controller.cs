using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamboController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private bool hasCookie;
    [SerializeField] private Texture2D CookieCursor;
    [SerializeField] private Texture2D DefaultCursor;
    [SerializeField] private float timeAwake;
    [SerializeField] private float timeLastWoken;

    private void Update()
	{
        timeAwake += Time.deltaTime;
        if (timeAwake >= 10.0f)
        {
            if (hasCookie)
            {
                animator.SetBool("Impatient", true);
            }
            else
            {
                animator.SetBool("IsAwake", false);
            }
        }
    }

    public void ClickOnFlambo()
    {
        if (hasCookie)
        {
            timeAwake = 0;
            Debug.Log("feed");
            hasCookie = false;
            animator.SetBool("SeesCookie", false);
            Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            timeAwake = 0;
            Debug.Log("wakeup");
            animator.SetBool("Startled", false);
            animator.SetBool("IsAwake", true);
        }
    }

    public void Airhorn()
    {
        timeAwake = 0;
        Debug.Log("airhorn");
        animator.SetTrigger("Startle");
        animator.SetBool("IsAwake", true);
    }

    public void GrabCookie()
    {
        timeAwake = 0;
        Debug.Log("Grab cookie");
        hasCookie = true;
        animator.SetBool("SeesCookie", true);
        Cursor.SetCursor(CookieCursor, new Vector2(CookieCursor.width/2, CookieCursor.height/2), CursorMode.Auto);
    }

    public void DropCookie()
    {
        timeAwake = 0;
        Debug.Log("Release cookie");
        hasCookie = false;
        animator.SetBool("SeesCookie", false);
        Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
