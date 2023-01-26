using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanController3D : MonoBehaviour
{
    [SerializeField] private Animator animator;

	private void Update()
	{
		if ( Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
		{
			animator.SetFloat("MoveSpeed", 1);
		}
		else
		{
			animator.SetFloat("MoveSpeed", 0);
		}
	}
}
