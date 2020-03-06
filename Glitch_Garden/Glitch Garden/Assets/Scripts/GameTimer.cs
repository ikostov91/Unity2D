using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer in SECONDS")]
    [SerializeField] float _levelTime = 10f;
    bool _triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (this._triggeredLevelFinished)
        {
            return;
        }

        this.GetComponent<Slider>().value = Time.timeSinceLevelLoad / this._levelTime;

        bool timerFinished = Time.timeSinceLevelLoad >= this._levelTime;
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimeFinished();
            this._triggeredLevelFinished = true;
        }
    }
}
