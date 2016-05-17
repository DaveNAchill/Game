using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	[System.Serializable]
	public class PlayerStats // Stats for the player(Health)
	{
		public int maxHealth = 100; // player health = 100

		private int _curHealth;

		public int curHealth
		{
			get { return _curHealth; }
			set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
		}

		public void Init()
		{
			curHealth = maxHealth;
		}
	}

	public PlayerStats stats = new PlayerStats();

	public int fallBoundary = -20; // How far the player can drop outside the map until he dies

	

	[SerializeField]
	private StatusIndicator statusIndicator;

	void Start()
	{
		stats.Init();

		if (statusIndicator == null)
		{
			Debug.LogError("No status indicator referenced on Player");
		}
		else
		{
			statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
		}
	}

	void Update () 
	{
		if (transform.position.y <= fallBoundary) // Damage when player falls outside the map
			DamagePlayer (9999999);
	}

	public void DamagePlayer (int damage) 
	{
		stats.curHealth -= damage;
		if (stats.curHealth <= 0) // current health less than 0 
		{
			GameMaster.KillPlayer(this); // kill the palyer(from the game master script) 
		}

		statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
	}

}
