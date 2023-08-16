using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageNav : MonoBehaviour
{
    /*
    public TextMeshProUGUI textMeshPro;
    public Button nextPageButton;
    public Button previousPageButton;

    private int currentPage = 0;
    private int maxPages;

    private void Start()
    {
        // Add click event listeners to buttons
        nextPageButton.onClick.AddListener(NextPage);
        previousPageButton.onClick.AddListener(PreviousPage);

        // Update button interactivity based on initial page count
        UpdateButtonInteractivity();

        // Register event handler for TextChanged
        textMeshPro.onTextChanged.AddListener(UpdateButtonInteractivity);
    }

    private void NextPage()
    {
        if (currentPage < maxPages - 1)
        {
            currentPage++;
            DisplayPage(currentPage);

            // Update button interactivity after page change
            UpdateButtonInteractivity();
        }
    }

    private void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            DisplayPage(currentPage);

            // Update button interactivity after page change
            UpdateButtonInteractivity();
        }
    }

    private void DisplayPage(int pageNumber)
    {
        textMeshPro.pageToDisplay = pageNumber;
    }

    private void UpdateButtonInteractivity(string newText)
    {
        // Calculate the number of pages
        maxPages = textMeshPro.textInfo.pageCount;

        // Enable or disable buttons based on page index
        nextPageButton.interactable = currentPage < maxPages - 1;
        previousPageButton.interactable = currentPage > 0;
    }
    */
}
