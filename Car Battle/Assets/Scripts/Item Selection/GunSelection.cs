using UnityEngine.UI;
using UnityEngine;

public class GunSelection : BaseSelection
{
    public static GunSelection instance;

    public int currentSelection = 0;
    public BaseGun[] guns;

    public Button leftGunArrowButton;
    public Button rightGunArrowButton;

    public Image gunImage;
    private Sprite[] allGunImages;

    private void Awake()
    {
        //Singleton
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    public void LoadGuns()
    {
        //Load all scriptable objects in assets directory
        Object[] _guns = Resources.LoadAll("ScriptableObjects/Guns");

        guns = new BaseGun[_guns.Length];
        _guns.CopyTo(guns, 0);

        //Load all Car Images in assets directory
        Object[] _allGunImages = Resources.LoadAll<Sprite>("Images/Guns");

        allGunImages = new Sprite[_allGunImages.Length];

        _allGunImages.CopyTo(allGunImages, 0);
    }

    public override void IncrementSelection()
    {
        ++currentSelection;
        CheckForArrowButtons();

        gunImage.sprite = allGunImages[currentSelection];
    }

    public override void DecrementSelection()
    {
        --currentSelection;
        CheckForArrowButtons();

        gunImage.sprite = allGunImages[currentSelection];
    }

    private void CheckForArrowButtons()
    {
        //Check for left arrow button
        if (currentSelection > 0)
            leftGunArrowButton.interactable = true;
        else
            leftGunArrowButton.interactable = false;

        //Check for right arrow button
        if (currentSelection < guns.Length - 1)
            rightGunArrowButton.interactable = true;
        else
            rightGunArrowButton.interactable = false;
    }
}
