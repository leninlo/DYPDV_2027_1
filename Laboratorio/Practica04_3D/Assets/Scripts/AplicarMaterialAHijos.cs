using UnityEngine;

public class AplicarMaterialAHijos : MonoBehaviour
{
    public Material materialComun;

    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.material = materialComun;
        }
    }
}