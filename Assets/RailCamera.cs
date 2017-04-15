using UnityEngine;

public class RailCamera : MonoBehaviour {

	// Exposed variables
	//--------------------------------

	[SerializeField] BezierCurve m_track;
	[SerializeField] float m_speed;

	float m_t;

	void Update()
	{
		m_t += m_speed * Time.deltaTime;
		if (m_t > 1.0f)
			m_t -= 1.0f;

		transform.position = m_track.GetPointAt(m_t);		
	}
}
