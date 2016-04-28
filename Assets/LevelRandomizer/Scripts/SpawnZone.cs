using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour {

	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (this.transform.position, 1);
		
	}
}
