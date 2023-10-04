using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Player GM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {

            GM.AddScore();
            // Destroy the collectible
            Destroy(gameObject);
            // Spawn a new collectible at a random position
            SpawnNewCollectible();
            IncreaseSize(transform);
        }
    }
    private void SpawnNewCollectible()
    {
        float Random_x = Random.Range(-5, 5);
        float Random_z = Random.Range(-5, 5);
        Vector3 newPosition = new Vector3(Random_x, 0, Random_z);
        Instantiate(gameObject, newPosition, Quaternion.identity);
    }

    private static void IncreaseSize(Component component)
    {
        component.transform.localScale += new Vector3(1, 1, 1);
    }
}