using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour
{
    [SerializeField] private List<Instantiator> instantiators;
    [SerializeField] private float delayBetweenInstantiators;

    public int InstantiatorsCount
    {
        get { return instantiators.Count; }
    }

    public void InstantiateSequence()
    {
        StartCoroutine(InstantiatorSequence());
    }

    public void InstantiateByIndex(int index)
    {
        if(index < 0 || index >= instantiators.Count)
        {
            Debug.LogErrorFormat("Cant instantiate with index {0}. Indicate and index between 0 and {1}", index, instantiators.Count);
            return;
        }
        var instantiator = instantiators[index];
        instantiator.DoInstantiate();
    }
    private IEnumerator InstantiatorSequence()
    {
        foreach(var instantiator in instantiators)
        {
            instantiator.DoInstantiate();
            yield return new WaitForSeconds(delayBetweenInstantiators);
        }
    }
}
