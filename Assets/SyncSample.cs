using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SyncSample : MonoBehaviour
{

    // Use this for initialization
    public GameObject prefab;
    public Text fps;
    public Text unscaledFps;
    public Text scale;

    [Range(1, 240)]
    public int targetFps = 50;

    [Range(0f, 100f)]
    public float timeScale = 1;
    float nextTime;
    int cnt;
    int prevCnt;
    float unscaledNextTime;
    int unscaledCnt;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Time.timeScale = timeScale;
        Time.captureFramerate = (int)(targetFps * timeScale);
        Application.targetFrameRate = (int)(targetFps * timeScale);
        nextTime = Time.time + 1;
        cnt = 0;
        unscaledNextTime = Time.unscaledTime + 1;
        unscaledCnt = 0;
    }

    void Update()
    {
        Time.timeScale = timeScale;
        Time.captureFramerate = (int)(targetFps * timeScale);
        Application.targetFrameRate = (int)(targetFps * timeScale);

        cnt++;
        if (Time.time >= nextTime)
        {
            Object.Instantiate(prefab, new Vector3(0, 5, 0), Quaternion.identity);
            fps.text = "" + cnt;
            prevCnt = cnt;
            cnt = 0;
            nextTime += 1;
        }
        unscaledCnt++;
        if (Time.unscaledTime >= unscaledNextTime)
        {
            unscaledFps.text = "" + unscaledCnt;
            scale.text = "x" + (float)unscaledCnt / prevCnt;
            unscaledCnt = 0;
            unscaledNextTime += 1;
        }
    }
}
