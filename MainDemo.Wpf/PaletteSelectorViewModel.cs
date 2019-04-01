﻿using System.Collections.Generic;
using System.Windows.Input;
using MaterialDesignColors.BigBlueBox2.Domain;
using MaterialDesignThemes.Wpf;

namespace MaterialDesignColors.BigBlueBox2
{
    public class PaletteSelectorViewModel
    {
        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;            
        }

        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public IEnumerable<Swatch> Swatches { get; }

        public ICommand ApplyPrimaryCommand { get; } = new AnotherCommandImplementation(o => ApplyPrimary((Swatch)o));

        private static void ApplyPrimary(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        public ICommand ApplyAccentCommand { get; } = new AnotherCommandImplementation(o => ApplyAccent((Swatch)o));

        private static void ApplyAccent(Swatch swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }
    }
}
