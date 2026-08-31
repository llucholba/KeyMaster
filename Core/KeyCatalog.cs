using System.Collections.Generic;
using System.Windows.Forms;
using KeyMaster.Models;

namespace KeyMaster.Core
{
    public static class KeyCatalog
    {
        public static List<KeyDefinition> GetKeys()
        {
            var keys = new List<KeyDefinition>();

            // Letras
            keys.Add(new KeyDefinition(Keys.A, "A"));
            keys.Add(new KeyDefinition(Keys.B, "B"));
            keys.Add(new KeyDefinition(Keys.C, "C"));
            keys.Add(new KeyDefinition(Keys.D, "D"));
            keys.Add(new KeyDefinition(Keys.E, "E"));
            keys.Add(new KeyDefinition(Keys.F, "F"));
            keys.Add(new KeyDefinition(Keys.G, "G"));
            keys.Add(new KeyDefinition(Keys.H, "H"));
            keys.Add(new KeyDefinition(Keys.I, "I"));
            keys.Add(new KeyDefinition(Keys.J, "J"));
            keys.Add(new KeyDefinition(Keys.K, "K"));
            keys.Add(new KeyDefinition(Keys.L, "L"));
            keys.Add(new KeyDefinition(Keys.M, "M"));
            keys.Add(new KeyDefinition(Keys.N, "N"));
            keys.Add(new KeyDefinition(Keys.O, "O"));
            keys.Add(new KeyDefinition(Keys.P, "P"));
            keys.Add(new KeyDefinition(Keys.Q, "Q"));
            keys.Add(new KeyDefinition(Keys.R, "R"));
            keys.Add(new KeyDefinition(Keys.S, "S"));
            keys.Add(new KeyDefinition(Keys.T, "T"));
            keys.Add(new KeyDefinition(Keys.U, "U"));
            keys.Add(new KeyDefinition(Keys.V, "V"));
            keys.Add(new KeyDefinition(Keys.W, "W"));
            keys.Add(new KeyDefinition(Keys.X, "X"));
            keys.Add(new KeyDefinition(Keys.Y, "Y"));
            keys.Add(new KeyDefinition(Keys.Z, "Z"));

            // Números
            keys.Add(new KeyDefinition(Keys.D0, "0"));
            keys.Add(new KeyDefinition(Keys.D1, "1"));
            keys.Add(new KeyDefinition(Keys.D2, "2"));
            keys.Add(new KeyDefinition(Keys.D3, "3"));
            keys.Add(new KeyDefinition(Keys.D4, "4"));
            keys.Add(new KeyDefinition(Keys.D5, "5"));
            keys.Add(new KeyDefinition(Keys.D6, "6"));
            keys.Add(new KeyDefinition(Keys.D7, "7"));
            keys.Add(new KeyDefinition(Keys.D8, "8"));
            keys.Add(new KeyDefinition(Keys.D9, "9"));

            // Funciones
            keys.Add(new KeyDefinition(Keys.F1, "F1"));
            keys.Add(new KeyDefinition(Keys.F2, "F2"));
            keys.Add(new KeyDefinition(Keys.F3, "F3"));
            keys.Add(new KeyDefinition(Keys.F4, "F4"));
            keys.Add(new KeyDefinition(Keys.F5, "F5"));
            keys.Add(new KeyDefinition(Keys.F6, "F6"));
            keys.Add(new KeyDefinition(Keys.F7, "F7"));
            keys.Add(new KeyDefinition(Keys.F8, "F8"));
            keys.Add(new KeyDefinition(Keys.F9, "F9"));
            keys.Add(new KeyDefinition(Keys.F10, "F10"));
            keys.Add(new KeyDefinition(Keys.F11, "F11"));
            keys.Add(new KeyDefinition(Keys.F12, "F12"));

            // Teclas especiales
            keys.Add(new KeyDefinition(Keys.Enter, "Enter"));
            keys.Add(new KeyDefinition(Keys.Escape, "Escape"));
            keys.Add(new KeyDefinition(Keys.Tab, "Tab"));
            keys.Add(new KeyDefinition(Keys.Space, "Space"));
            keys.Add(new KeyDefinition(Keys.Back, "Backspace"));
            keys.Add(new KeyDefinition(Keys.Delete, "Delete"));
            keys.Add(new KeyDefinition(Keys.Insert, "Insert"));
            keys.Add(new KeyDefinition(Keys.Home, "Home"));
            keys.Add(new KeyDefinition(Keys.End, "End"));
            keys.Add(new KeyDefinition(Keys.PageUp, "Page Up"));
            keys.Add(new KeyDefinition(Keys.PageDown, "Page Down"));

            // Modificadores
            keys.Add(new KeyDefinition(Keys.LControlKey, "Ctrl izquierdo"));
            keys.Add(new KeyDefinition(Keys.RControlKey, "Ctrl derecho"));
            keys.Add(new KeyDefinition(Keys.LShiftKey, "Shift izquierdo"));
            keys.Add(new KeyDefinition(Keys.RShiftKey, "Shift derecho"));
            keys.Add(new KeyDefinition(Keys.LMenu, "Alt izquierdo"));
            keys.Add(new KeyDefinition(Keys.RMenu, "Alt derecho"));

            return keys;
        }
    }
}