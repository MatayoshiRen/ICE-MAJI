using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcountseisei : MonoBehaviour
{
    int start = 0;
    int end = 2;
    int count = 3;
    int index;
    int ransu;
    public GameObject[] Item;

    List<int> numbers = new List<int>();
    void Start()
    {
        
        StartCoroutine("Repop");
    }

    IEnumerator Repop()
    {
        while (true)
        {
            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }
            while (count-- > 0)
            {
                index = Random.Range(0, numbers.Count);
                ransu = numbers[index];
                GameObject  item = Instantiate(Item[ransu], this.transform.position, Quaternion.identity) as GameObject;
                numbers.RemoveAt(index);
                yield return new WaitForSeconds(3);
                Destroy(item);
            }
           // Debug.Log("再抽選");
            count = 3;
        }
    }

}
