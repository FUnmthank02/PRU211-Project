using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Our enemy to spawn
    public GameObject enermy;
    private Transform enermyTransform;
    // We want to delay our code at certain times
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = .25f;
    public float timeBeforeWaves = 2.0f;
    public int enemiesPerWave = 5;
    private int currentNumberOfEnemies = 0;
    void Start()
    {
        enermyTransform = enermy.transform;
        StartCoroutine(SpawnEnemies());
    }

    // spawn small enermies (goblin)
    IEnumerator SpawnEnemies()
    {
        // Give the player time before we start the game
        yield return new WaitForSeconds(timeBeforeSpawning);

        Camera mainCamera = Camera.main;
        float height = 2.0f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        // Get the position of the camera in world units
        Vector3 cameraPosition = mainCamera.transform.position;

        // Calculate the position for spawning in the left and right edges of the camera view
        Vector3 leftPositionSpawn = cameraPosition - (mainCamera.transform.right * width / 2.0f) + new Vector3(-2, 0, 0);
        Vector3 rightPositionSpawn = cameraPosition + (mainCamera.transform.right * width / 2.0f) + new Vector3(2, 0, 0);

        // Three times spawning
        int limitSpawn = 3;
        while (limitSpawn <= 3 && limitSpawn >= 1)
        {
            // Don't spawn anything new until all the previous wave's enemies are dead
            if (currentNumberOfEnemies <= 0)
            {
                //Spawn enemies in a random position
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    var rand = Random.Range(0, 1f);
                    Instantiate(enermyTransform,rightPositionSpawn, Quaternion.identity);
                    currentNumberOfEnemies++;
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
            }
            yield return new WaitForSeconds(timeBeforeWaves);
            limitSpawn--;
        }
    }
}