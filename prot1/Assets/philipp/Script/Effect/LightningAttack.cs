using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleEmitter))]
[RequireComponent(typeof(ParticleRenderer))]
public class LightningAttack : MonoBehaviour
{
	public Transform target;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
	public Vector3 awayPosition = new Vector3(-999.0f,-999.0f,-999.0f);

	private bool attackOn = false;	
	private bool hit = false;
	private float damage = 0.0f;

	private Perlin noise;
	private float oneOverZigs;
	
	private Particle[] particles;

	public bool IsHit()
	{
		return hit;
	}

	void Start()
	{
		oneOverZigs = 1f / (float)zigs;
		particleEmitter.emit = false;
		
		particleEmitter.Emit(zigs);
		particles = particleEmitter.particles;
	}
	
	void FixedUpdate()
	{
		hit = false;
		if (!attackOn)
			return;

		if (noise == null)
			noise = new Perlin();

		GameObject parent = transform.parent.gameObject;
		Vector3 dir = parent.transform.position - target.position;
		float distance = dir.magnitude;
		dir /= distance;
		RaycastHit rayHit = new RaycastHit();
		Vector3 colPos;
		if (Physics.Raycast(target.position, dir, out rayHit, distance))
		{
			colPos = rayHit.point;
			if ((rayHit.collider.gameObject == parent) )
			{
				Creep creep = parent.GetComponent<Creep>();
				creep.Damage(Time.deltaTime * damage);
				hit = true;
			}
		}
		else
		{
			colPos = parent.transform.position;
			parent.GetComponentInParent<Creep>().Damage(Time.deltaTime * damage);
			hit = true;
		}

		float timex = Time.time * speed * 0.1365143f;
		float timey = Time.time * speed * 1.21688f;
		float timez = Time.time * speed * 2.5564f;
		
		for (int i=0; i < particles.Length; i++)
		{
			Vector3 position = Vector3.Lerp(colPos, target.position, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
			                             noise.Noise(timey + position.x, timey + position.y, timey + position.z),
			                             noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			position += (offset * scale * ((float)i * oneOverZigs));
			
			particles[i].position = position;
			particles[i].color = Color.white;
			particles[i].energy = 1f;
		}
		
		particleEmitter.particles = particles;
	}	

	public void SetAttackOn(bool a, float attackPower)
	{
		damage = attackPower;
		attackOn = a;
		if (attackOn)
		{
			GetComponent<ParticleRenderer>().enabled = true;
		}
		else
		{
			particleEmitter.ClearParticles();
		}
	}
}
