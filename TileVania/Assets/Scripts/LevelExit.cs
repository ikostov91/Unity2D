using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float _loadDelay = 0.2f;
    [SerializeField] private float _levelExitSlowMoFactor = 0.2f;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        this.StartCoroutine(this.LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        Time.timeScale = this._levelExitSlowMoFactor;
        yield return new WaitForSeconds(this._loadDelay);
        Time.timeScale = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
