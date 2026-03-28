using UnityEngine;
using TMPro; // Importante ni kay TextMeshPro imong gamit

public class WizardDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    
    // Pwede nimo usbon kini nga mensahe didto ra sa Unity Inspector!
    public string message = "ako si hylla buang.";

    void Start()
    {
        // Gitago ang bintana inig sugod sa dula
        dialoguePanel.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kung makaduol ang player, ipagawas ang bintana
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = message;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Kung molayo ang player, tago-on balik ang bintana
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);
        }
    }
}