using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	[SerializeField] private Animator ani;

	private void Update()
	{
		PlayerPrefs.SetFloat("Score", 4);

		PlayerPrefs.GetFloat("Score");
	}
}
