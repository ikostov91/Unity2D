using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> wayPoints;
    [SerializeField] float moveSpeed = 2f;
    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // EnemyPathing is added to enemy therefore
        // transform.position is connected to the current object
        // this script is added to => Enemy
        this.wayPoints = this.waveConfig.GetWaypoints();
        transform.position = this.wayPoints[this.wayPointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= this.wayPoints.Count - 1)
        {
            var targetPosition = this.wayPoints[this.wayPointIndex].position;
            var movementThisFrame = this.moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                this.gameObject.transform.position,
                targetPosition,
                movementThisFrame);

            if (this.gameObject.transform.position == targetPosition)
            {
                this.wayPointIndex++;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
