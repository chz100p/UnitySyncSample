using UnityEngine;
using System.Collections;

public class SyncSample : MonoBehaviour {

	// Use this for initialization
	public GameObject prefab;
	int targetFps = 10;

	[Range(0.1f, 100f)]
	public float timeScale = 1;

	void Start () {
	}

	int cnt = 0;
	void Update () {
		QualitySettings.vSyncCount = 0;
		float deltaTime = 1.0f / (float)targetFps;
		Time.timeScale = timeScale;
		Time.captureFramerate = (int)(1.0f / deltaTime * timeScale);
		//Application.targetFrameRate = 300;

		cnt++;
		if (cnt % targetFps == 0) {
			Object.Instantiate(prefab, new Vector3(0,5,0), Quaternion.identity);
			Debug.Log ((cnt/targetFps).ToString() + "sec passed.");
		}
	}
}
