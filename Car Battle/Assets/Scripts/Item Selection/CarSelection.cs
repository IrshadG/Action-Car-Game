using UnityEngine;
using UnityEngine.UI;

public class CarSelection : BaseSelection 
{
    public static CarSelection instance;

    public int currentSelection = 0;
    public BaseCar[] cars;

    public Button leftCarArrowButton;
    public Button rightCarArrowButton;

    public Image carImage;
    private Sprite[] allCarImages;

    private void Awake()
    {
        //Singleton
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void LoadCars()
    {
        //Load all scriptable objects in assets directory
        Object[] _cars = Resources.LoadAll("ScriptableObjects/Cars");

        cars = new BaseCar[_cars.Length];
        _cars.CopyTo(cars, 0);


        //Load all Car Images in assets directory
        Object[] _allCarImages = Resources.LoadAll<Sprite>("Images/Cars") ;

        allCarImages = new Sprite[_allCarImages.Length];

        _allCarImages.CopyTo(allCarImages,0);
    }

    public override void IncrementSelection()
    {
        ++currentSelection;
        CheckForArrowButtons();

        carImage.sprite = allCarImages[currentSelection];
    }

    public override void DecrementSelection()
    {
        --currentSelection;
        CheckForArrowButtons();

        carImage.sprite = allCarImages[currentSelection];
    }

    private void CheckForArrowButtons()
    {
        //Check for left arrow button
        if (currentSelection > 0)
            leftCarArrowButton.interactable = true;
        else
            leftCarArrowButton.interactable = false;

        //Check for right arrow button
        if (currentSelection < cars.Length - 1)
            rightCarArrowButton.interactable = true;
        else
            rightCarArrowButton.interactable = false;
    }
}
