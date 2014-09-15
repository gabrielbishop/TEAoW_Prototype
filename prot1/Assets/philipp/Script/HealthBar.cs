using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour 
{
	public Texture2D backgroundTexture;
	public Texture2D foregroundTexture;

	public float healthbarWidth = 100.0f;
	public float healthbarHeight = 10.0f;
	public float margin = 0.2f;

	public float healthInPercent = 2.0f;
	public Vector3 positionOffset = new Vector3(0.0f,1.0f,0.0f);

	void OnGUI()
	{
		Vector2 targetPos = Camera.main.WorldToScreenPoint(transform.position + positionOffset);
		float halfWidth = healthbarWidth * 0.5f;
		GUI.DrawTexture(new Rect(targetPos.x - halfWidth, Screen.height - targetPos.y, healthbarWidth, healthbarHeight), backgroundTexture);
		GUI.DrawTexture(new Rect(targetPos.x - halfWidth + margin, Screen.height - targetPos.y + margin, (healthbarWidth - 2.0f * margin) * healthInPercent , healthbarHeight - 2.0f * margin), foregroundTexture);
	}
}
