using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player owner;

    public void spawnUnits (List<Unit> units)
    {
        foreach (Unit unit in units)
        {
            StartCoroutine("spawnUnit", unit);
        }
    }

    public IEnumerator spawnUnit(Unit unit)
    {
        Unit _unit = Instantiate(unit, gameObject.transform.position, Quaternion.identity);
        _unit.transform.parent = gameObject.transform;
        _unit.owner = owner;
        _unit.transform.localScale = new Vector3(owner.direction, 1f, 1f);
        _unit.transform.GetChild(0).transform.localScale = new Vector3(owner.direction, 1f, 1f); ;
        yield return new WaitForSeconds(2f);
    }
}
