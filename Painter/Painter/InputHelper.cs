using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Painter
{
    public class InputHelper
    {
        MouseState currentMouseState;
        MouseState previousMouseState;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        //Vector2 position;
        
        //////
        public void Update()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
        //get mouse position
        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }
        //mouse state
        public bool MouseLeftButtonPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed
           && previousMouseState.LeftButton == ButtonState.Released;
        }
        //key state
        public bool KeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }

    }
}
