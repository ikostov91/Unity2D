using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig _waveConfig;
    List<Transform> _wayPoints;
    int _wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // EnemyPathing is added to enemy therefore
        // transform.position is connected to the current object
        // this script is added to => Enemy
        this._wayPoints = this._waveConfig.GetWaypoints();
        transform.position = this._wayPoints[this._wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this._waveConfig = waveConfig;
    }

    private void Move()
    {
        if (_wayPointIndex <= this._wayPoints.Count - 1)
        {
            var targetPosition = this._wayPoints[this._wayPointIndex].position;
            var movementThisFrame = this._waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                this.gameObject.transform.position,
                targetPosition,
                movementThisFrame);

            if (this.gameObject.transform.position == targetPosition)
            {
                this._wayPointIndex++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
