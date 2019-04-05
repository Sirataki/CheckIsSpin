using UnityEngine;

public class JoystickInput : MonoBehaviour
{
	[SerializeField] private float radius;
	[SerializeField] private int threshold;
	[SerializeField] private RectTransform handle = null;
	[SerializeField] private JoystickInputCollider[] inputCollider = new JoystickInputCollider[0];

	protected int m_Cost;

	public bool IsSpin
	{
		get { return m_Cost > threshold; }
	}

	void Start()
	{
		Vector2 center = new Vector2(0.5f, 0.5f);
		handle.anchorMin = center;
		handle.anchorMax = center;
		handle.pivot = center;
		handle.anchoredPosition = Vector2.zero;
	}

	void Update()
	{
		handle.anchoredPosition = InputAxis() * radius;

		m_Cost = 0;
		for (int i = 0; i < inputCollider.Length; ++i)
		{
			m_Cost += inputCollider[i].Cost;
		}
	}

	private Vector2 InputAxis()
	{
		Vector2 axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		return axis;
	}
}
