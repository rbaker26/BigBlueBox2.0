using System.Configuration;
using BigBlueBox2;
using BigBlueBox2._0.src;
using BigBlueBox2._0.pages;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System.Windows.Controls;
using System;


// TODO
// Add menu items here

namespace BigBlueBox2._0.src
{
    public class MainWindowViewModel
    {

        public MainWindowViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));

            MenuItems = new[]
            {
                new MenuItem("Home", new Home(),
                    new []
                    {
                        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                        DocumentationLink.DemoPageLink<Home>()
                    }
                ),
                new MenuItem("Inventory Manager", new Inventory_Page(),
                    new []
                    {
                        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                        DocumentationLink.DemoPageLink<Home>()
                    }
                ),
                new MenuItem("Gear Checkout", new Gear_Page(),
                    new []
                    {
                        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                        DocumentationLink.DemoPageLink<Home>()
                    }
                ),
                new MenuItem("Gear Manager", new Gear_Page(),
                    new []
                    {
                        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                        DocumentationLink.DemoPageLink<Home>()
                    }
                ),
                #region temp
                //new MenuItem("Inventory Splash Screen", new InventorySplashScreen(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Inventory", new Inventory_Page(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Gear Splash Screen", new Home(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),

                //new MenuItem("Asset Tags", new Home(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Analytics", new Home(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Accounts", new Home(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Settings", new Home(),
                //    new []
                //    {
                //        new DocumentationLink(DocumentationLinkType.Wiki, $"{ConfigurationManager.AppSettings["GitHub"]}/wiki", "WIKI"),
                //        DocumentationLink.DemoPageLink<Home>()
                //    }
                //),
                //new MenuItem("Palette", new PaletteSelector { DataContext = new PaletteSelectorViewModel() },
                //    new []
                //    {
                //        DocumentationLink.WikiLink("Brush-Names", "Brushes"),
                //        DocumentationLink.WikiLink("Custom-Palette-Hues", "Custom Palettes"),
                //        DocumentationLink.WikiLink("Swatches-and-Recommended-Colors", "Swatches"),
                //        DocumentationLink.DemoPageLink<PaletteSelector>("Demo View"),
                //        DocumentationLink.DemoPageLink<PaletteSelectorViewModel>("Demo View Model"),
                //        DocumentationLink.ApiLink<PaletteHelper>()
                //    }),
                //new MenuItem("Buttons & Toggles", new Buttons { DataContext = new ButtonsViewModel() } ,
                //    new []
                //    {
                //        DocumentationLink.WikiLink("Button-Styles", "Buttons"),
                //        DocumentationLink.DemoPageLink<Buttons>("Demo View"),
                //        DocumentationLink.DemoPageLink<ButtonsViewModel>("Demo View Model"),
                //        DocumentationLink.StyleLink("Button"),
                //        DocumentationLink.StyleLink("CheckBox"),
                //        DocumentationLink.StyleLink("PopupBox"),
                //        DocumentationLink.StyleLink("ToggleButton"),
                //        DocumentationLink.ApiLink<PopupBox>()
                //    })
                //    {
                //        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                //    },
                //new MenuItem("Fields", new TextFields(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<TextFields>(),
                //        DocumentationLink.StyleLink("TextBox"),
                //        DocumentationLink.StyleLink("ComboBox"),
                //    })
                //    {
                //        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                //    },
                //new MenuItem("Pickers", new Pickers { DataContext = new PickersViewModel()},
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Pickers>(),
                //        DocumentationLink.StyleLink("Clock"),
                //        DocumentationLink.StyleLink("DatePicker"),
                //        DocumentationLink.ApiLink<TimePicker>()
                //    }),
                //new MenuItem("Sliders", new Sliders(), new []
                //    {
                //        DocumentationLink.DemoPageLink<Sliders>(),
                //        DocumentationLink.StyleLink("Slider")
                //    }),
                //new MenuItem("Chips", new Chips(), new []
                //    {
                //        DocumentationLink.DemoPageLink<Chips>(),
                //        DocumentationLink.StyleLink("Chip"),
                //        DocumentationLink.ApiLink<Chip>()
                //    }),
                //new MenuItem("Typography", new Typography(), new []
                //    {
                //        DocumentationLink.DemoPageLink<Typography>(),
                //        DocumentationLink.StyleLink("TextBlock")
                //    })
                //    {
                //        VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto,
                //        HorizontalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                //    },
                //new MenuItem("Cards", new Cards(), new []
                //    {
                //        DocumentationLink.DemoPageLink<Cards>(),
                //        DocumentationLink.StyleLink("Card"),
                //        DocumentationLink.ApiLink<Card>()
                //    })
                //{
                //    VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                //},
                //new MenuItem("Icon Pack", new IconPack { DataContext = new IconPackViewModel(snackbarMessageQueue) },
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<IconPack>("Demo View"),
                //        DocumentationLink.DemoPageLink<IconPackViewModel>("Demo View Model"),
                //        DocumentationLink.ApiLink<PackIcon>()
                //    }),
                //new MenuItem("Colour Zones", new ColorZones(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<ColorZones>(),
                //        DocumentationLink.ApiLink<ColorZone>()
                //    }),
                //new MenuItem("Lists", new Lists { DataContext = new ListsAndGridsViewModel()},
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Lists>("Demo View"),
                //        DocumentationLink.DemoPageLink<ListsAndGridsViewModel>("Demo View Model", "Domain"),
                //        DocumentationLink.StyleLink("ListBox"),
                //        DocumentationLink.StyleLink("ListView")
                //    })
                //{
                //    VerticalScrollBarVisibilityRequirement = ScrollBarVisibility.Auto
                //},
                //new MenuItem("Trees", new Trees { DataContext = new TreesViewModel() },
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Trees>("Demo View"),
                //        DocumentationLink.DemoPageLink<TreesViewModel>("Demo View Model"),
                //        DocumentationLink.StyleLink("TreeView")
                //    }),
                //new MenuItem("Grids", new Grids { DataContext = new ListsAndGridsViewModel()},
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Grids>("Demo View"),
                //        DocumentationLink.DemoPageLink<ListsAndGridsViewModel>("Demo View Model", "Domain"),
                //        DocumentationLink.StyleLink("DataGrid")
                //    }),
                //new MenuItem("Expander", new Expander(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Expander>(),
                //        DocumentationLink.StyleLink("Expander")
                //    }),
                //new MenuItem("Group Boxes", new GroupBoxes(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<GroupBoxes>(),
                //        DocumentationLink.StyleLink("GroupBox")
                //    }),
                //new MenuItem("Menus & Tool Bars", new MenusAndToolBars(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<MenusAndToolBars>(),
                //        DocumentationLink.StyleLink("Menu"),
                //        DocumentationLink.StyleLink("ToolBar")
                //    }),
                //new MenuItem("Progress Indicators", new Progress(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Progress>(),
                //        DocumentationLink.StyleLink("ProgressBar")
                //    }),
                //new MenuItem("Dialogs", new Dialogs { DataContext = new DialogsViewModel()},
                //    new []
                //    {
                //        DocumentationLink.WikiLink("Dialogs", "Dialogs"),
                //        DocumentationLink.DemoPageLink<Dialogs>("Demo View"),
                //        DocumentationLink.DemoPageLink<DialogsViewModel>("Demo View Model", "Domain"),
                //        DocumentationLink.ApiLink<DialogHost>()
                //    }),
                //new MenuItem("Drawer", new Drawers(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Drawers>(),
                //        DocumentationLink.ApiLink<DrawerHost>()
                //    }),
                //new MenuItem("Snackbar", new Snackbars(),
                //    new []
                //    {
                //        DocumentationLink.WikiLink("Snackbar", "Snackbar"),
                //        DocumentationLink.DemoPageLink<Snackbars>(),
                //        DocumentationLink.StyleLink("Snackbar"),
                //        DocumentationLink.ApiLink<Snackbar>(),
                //        DocumentationLink.ApiLink<ISnackbarMessageQueue>()
                //    }),
                //new MenuItem("Transitions", new Transitions(),
                //    new []
                //    {
                //        DocumentationLink.WikiLink("Transitions", "Transitions"),
                //        DocumentationLink.DemoPageLink<Transitions>(),
                //        DocumentationLink.ApiLink<Transitioner>("Transitions"),
                //        DocumentationLink.ApiLink<TransitionerSlide>("Transitions"),
                //        DocumentationLink.ApiLink<TransitioningContent>("Transitions"),
                //    }),
                //new MenuItem("Shadows", new Shadows(),
                //    new []
                //    {
                //        DocumentationLink.DemoPageLink<Shadows>(),
                //    }),
#endregion
            };
        }

        public MenuItem[] MenuItems { get; }


    }
}
