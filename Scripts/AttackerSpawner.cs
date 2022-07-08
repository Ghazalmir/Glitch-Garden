using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float  minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 10f;
    [SerializeField] Attacker[] attackerPrefabsArray;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAttacker()
    {
        int index = Random.Range(0, attackerPrefabsArray.Length);
        Spawn(attackerPrefabsArray[index]);
    }

    private void  Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate (attacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
