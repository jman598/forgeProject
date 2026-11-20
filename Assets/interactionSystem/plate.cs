using UnityEngine;

public class plate : MonoBehaviour
{
    public string requiredTag = "PuzzleBlock";
    public puzzleManager puzzleManager;

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag(requiredTag))
        {
            activated = true;
            puzzleManager.PlateActivated();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (activated && other.CompareTag(requiredTag))
        {
            activated = false;
            puzzleManager.PlateDeactivated();
        }
    }
}
