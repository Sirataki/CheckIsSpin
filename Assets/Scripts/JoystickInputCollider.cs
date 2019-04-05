using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class JoystickInputCollider : MonoBehaviour
{
	protected int value;		//InActive=0,Active=1

	public int Cost
	{
		get { return value; }
	}

	WaitForSeconds m_Wait;

	Coroutine m_WaitCoroutine;

	const float k_InputDuration = 0.3f;

	void Awake()
	{
		m_Wait = new WaitForSeconds(k_InputDuration);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (m_WaitCoroutine != null)
		{
			StopCoroutine(m_WaitCoroutine);
		}
		m_WaitCoroutine = StartCoroutine(InputWait());
	}

	IEnumerator InputWait()
	{
		value = 1;

		yield return m_Wait;

		value = 0;
	}
}
