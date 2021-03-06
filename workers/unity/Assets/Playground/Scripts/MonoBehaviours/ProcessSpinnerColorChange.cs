using System.Collections.Generic;
using Generated.Playground;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Playground;
using UnityEngine;
using Color = Generated.Playground.Color;

public class ProcessSpinnerColorChange : MonoBehaviour
{
    [Require] private Collisions.Requirables.Reader collisionsReader;
    [Require] private SpinnerColor.Requirables.Reader colorReader;

    private float collideTime;
    private bool flashing;

    [SerializeField] private float flashTime = 0.2f;

    private MeshRenderer meshRenderer;

    private static Dictionary<Color, MaterialPropertyBlock> materialPropertyBlocks;
    private static MaterialPropertyBlock flashingMaterial;

    [RuntimeInitializeOnLoadMethod]
    public static void SetupColors()
    {
        flashingMaterial = new MaterialPropertyBlock();
        flashingMaterial.SetColor("_Color", UnityEngine.Color.magenta);
        ColorTranslationUtil.PopulateMaterialPropertyBlockMap(out materialPropertyBlocks);
    }

    private void OnEnable()
    {
        collisionsReader.OnPlayerCollided += HandleCollisionEvent;
        colorReader.ColorUpdated += HandleColorChange;
    }

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("No MeshRenderer on GameObject with MonoBehaviour ProcessSpinnerColorChange!");
        }
    }

    private void OnDisable()
    {
        collisionsReader.OnPlayerCollided -= HandleCollisionEvent;
        colorReader.ColorUpdated -= HandleColorChange;
    }

    private void HandleCollisionEvent(Empty empty)
    {
        collideTime = Time.time;
        flashing = true;
        meshRenderer.SetPropertyBlock(flashingMaterial);
    }

    private void HandleColorChange(Color color)
    {
        if (!flashing)
        {
            meshRenderer.SetPropertyBlock(materialPropertyBlocks[color]);
        }
    }

    private void Update()
    {
        if (flashing && Time.time - collideTime > flashTime)
        {
            meshRenderer.SetPropertyBlock(materialPropertyBlocks[colorReader.Data.Color]);
            flashing = false;
        }
    }
}
