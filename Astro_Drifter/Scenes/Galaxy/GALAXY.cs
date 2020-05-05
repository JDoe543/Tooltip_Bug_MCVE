using Godot;
using System;
using System.Collections.Generic;

public class GALAXY : Node2D
{
    private TextureButton _playerShip;
    private List<TextureButton> stars;

    public override void _Ready()
    {
        GD.Randomize();
        
        this.stars = createStars();
        
        // initialize gui nodes
        this._playerShip = (TextureButton) GetNode("PlayerShip");

        DisplayGalaxy();

        // raise gui nodes
        this._playerShip.Raise();

        SetShipPosition(new Vector2((12 << 5), (12 << 5)));
    }

    private List<TextureButton> createStars()
    {
        Random rand = new Random();
        List<TextureButton> stars = new List<TextureButton>();
        
        Texture classO = (Texture) GD.Load("res://Scenes/Galaxy/Art/Class_O.png");
        
        HashSet<Vector2> positions = new HashSet<Vector2>();

        for (int i = 0; i < 10; i++)
        {
            TextureButton star = new TextureButton();
            star.TextureNormal = classO;
            
            star.RectPosition = new Vector2((rand.Next(0, 26) << 5), (rand.Next(0, 26)) << 5);
            star.HintTooltip = "INFO";
            
            while (positions.Contains(star.RectPosition))
            {
                star.RectPosition = new Vector2((rand.Next(0, 26) << 5), (rand.Next(0, 26)) << 5);
                star.HintTooltip = "INFO";
            }
            
            stars.Add(star);
            positions.Add(star.RectPosition);
        }

        return stars;
    }

    /// <summary>
    /// Displays the galaxy by adding star Sprites as children to the root node.
    /// </summary>
    private void DisplayGalaxy()
    {
        for (int i = 0; i < this.stars.Count; i++)
        {
            this.AddChild(this.stars[i]);
        }
    }
    
    /// <summary>
    /// Sets the player's ship-location, and update's the player's location in
    /// GAMEPLAY.Player.StarLocation to the same position.
    /// </summary>
    private void SetShipPosition(Vector2 location)
    {
        this._playerShip.SetPosition(location);
    }
}