using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour 
{

	public static GameMaster gm;

	void Start () {
		if (gm == null) 
		{
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;
	public Transform spawnPrefab;

	public IEnumerator _RespawnPlayer () 
	{
		Debug.Log("HERE2");
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		Destroy (clone, 2f);
	}

	public static void KillPlayer (Player player)
	{
		Destroy (player.gameObject); // kill player
		Debug.Log("HERE");
		gm.StartCoroutine(gm._RespawnPlayer()); // respawn player
	}
	
	public static void KillEnemy(Enemy enemy)
	{
		Destroy(enemy.gameObject); // kill enemy
	}

}