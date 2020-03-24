using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ro : MonoBehaviour
{
    public GameObject rod;
    string rodotext;
    // Start is called before the first frame update
    void Start()
    {
        Text rodo = rod.GetComponent<Text>();
        rodotext = "ろぉでぃんぐちゅう";
        rodo.text = rodotext;
        StartCoroutine("rodokun");
    }

    public void rood()
    {
    rod.SetActive(true);
    }
  IEnumerator rodokun()
    {Text rodo = rod.GetComponent<Text>();
        while (true)
        {         
            yield return new WaitForSeconds(2f);
            rodotext = "ろぉでぃんぐちゅう";
            rodo.text = rodotext;
            yield return new WaitForSeconds(2f);
            rodotext = "ろぉでぃんぐちゅう.";
            rodo.text = rodotext;
            yield return new WaitForSeconds(2f);
            rodotext = "ろぉでぃんぐちゅう..";
            rodo.text = rodotext;
            yield return new WaitForSeconds(2f);
            rodotext = "ろぉでぃんぐちゅう...";
            rodo.text = rodotext;
        }
       
    }
}
