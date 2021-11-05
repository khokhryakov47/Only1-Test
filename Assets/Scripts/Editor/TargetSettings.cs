using UnityEditor;
using UnityEngine;

public class TargetSettings : Editor
{
#if UNITY_EDITOR
    [MenuItem("CONTEXT/Target/Setup")]
    static void SetupTarget(MenuCommand command)
    {
        Target target = (Target)command.context;

        MeshRenderer[] meshRenderers = target.GetComponentsInChildren<MeshRenderer>();

        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.gameObject.AddComponent<Block>();
            meshRenderer.gameObject.AddComponent<BoxCollider>();
            Rigidbody rigidbody = meshRenderer.gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
        }
    }
#endif
}