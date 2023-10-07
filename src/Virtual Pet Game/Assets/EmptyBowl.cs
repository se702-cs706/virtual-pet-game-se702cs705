using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBowl : MonoBehaviour
{
    public GameObject food;
    private bool isBowlEmpty = false;
    private Renderer[] sueloRenderers;
    [SerializeField] private ModelPresenter mp;
    private void Start()
    {
        GameObject[] suelo = GameObject.FindGameObjectsWithTag("Food_1");
        sueloRenderers = new Renderer[suelo.Length];
        for (int i = 0; i < sueloRenderers.Length; i++)
        {
            sueloRenderers[i] = suelo[i].GetComponent<Renderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBowlEmpty == true)
        {
            isBowlEmpty=true;
            transform.Find("Food_1").GetComponent<MeshRenderer>().enabled = false;
            //food.GetComponent<MeshFilter>().mesh = null;
            // Implement logic for an empty bowl
            // This could involve hiding the dog food, changing the texture, or other visual changes.
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Retriever_Color_1")
        {
            EnableRenderer(sueloRenderers, false);
            Debug.Log("Oculta suelo");

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Retriever_Color_1")
        {
            EnableRenderer(sueloRenderers, true);
            Debug.Log("Aparece suelo");

        }
    }
    void EnableRenderer(Renderer[] rd, bool enable)
    {
        for (int i = 0; i < rd.Length; i++)
        {
            rd[i].enabled = enable;
        }
    }
}
