using CommunityToolkit.Maui.Markup;
using ConferenceMauiDemo.Models;
using ConferenceMauiDemo.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Layouts;
using System.Runtime.CompilerServices;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace ConferenceMauiDemo.Views
{
    public class SessionsPageMarkup : ContentPage
    {
        private readonly SessionsPageViewModel _viewModel;
        public SessionsPageMarkup(SessionsPageViewModel viewModel)
        {
            this.BindingContext = _viewModel = viewModel;

        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            await _viewModel.Initialize();
            Build();
#if DEBUG
            HotReloadService.UpdateApplicationEvent += ReloadUI;
#endif
        }

        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);

#if DEBUG
            HotReloadService.UpdateApplicationEvent -= ReloadUI;
#endif
        }

        private void ReloadUI(Type[] obj)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Build();
            });
        }

        private void Build()
        {
            BuildMenu();

            Content = new Grid()
            {

                RowDefinitions = Rows.Define(
                    (Row.Header, Auto),
                    (Row.Content, Star)
                    ),
                Children =
                {
                    new Label().Text("Programm").FontSize(25).Margin(new Thickness(10,0,10,10)),
                    new CollectionView().Row(Row.Content)
                        .Bind(CollectionView.ItemsSourceProperty, nameof(SessionsPageViewModel.Sessions))
                        .ItemTemplate(new SessionTemplateSelector
                        {
                            BreakTemplate = BuildBreakTemplate(),
                            SessionTemplate = BuildSessionTemplate()
                        })
                }
            }.AppThemeBinding(BackgroundColorProperty, Color.FromArgb("F0F1F7"), Colors.Black);
        }



        private void BuildMenu()
        {
            var fileMenu = new MenuBarItem { Text = "Datei" };
            fileMenu.Add(new MenuFlyoutItem().Text("Export"));
            fileMenu.Add(new MenuFlyoutItem().Text("Beenden"));
            var helpMenu = new MenuBarItem { Text = "Hilfe" };
            helpMenu.Add(new MenuFlyoutItem().Text("Info"));

            MenuBarItems.Clear();
            MenuBarItems.Add(fileMenu);
            MenuBarItems.Add(helpMenu);
        }

        private DataTemplate BuildBreakTemplate()
        {
            var template = new DataTemplate(() =>
                new Border
                {
                    StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10), StrokeThickness = 0 },
                    Content = new Grid
                    {
                        RowDefinitions = Rows.Define
                        (
                            (NumericRows.First, Auto),
                            (NumericRows.Second, Auto),
                            (NumericRows.Third, Auto)
                        ),
                        ColumnDefinitions = Columns.Define
                        (
                            (NumericCols.First, 5),
                            (NumericCols.Second, 150),
                            (NumericCols.Third, Star)
                        ),
                        Children =
                        {
                            new BoxView{ Color = GetColorFromResource("Cyan100Accent"), VerticalOptions = LayoutOptions.Fill }.RowSpan(3),
                            new Label().Bind(Label.TextProperty, nameof(Session.Time)).Column(NumericCols.Third),
                            new Label().Bind(Label.TextProperty, nameof(Session.Title))
                                .Row(NumericRows.Second)
                                .Column(NumericCols.Third)
                                .FontSize(16).Font(bold: true)
                        }
                    }
                }
                .AppThemeColorBinding(BackgroundColorProperty, Colors.White, GetColorFromResource("Gray600"))
                .Margin(5)
                .Padding(0)
            );
            return template;
        }

        private static Color GetColorFromResource(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out object value))
            {
                return (Color)value;
            }
            throw new KeyNotFoundException($"Color {key} not found in resource dictionary");
        }

        private static string GetStringFromResource(string key)
        {
            if (Application.Current.Resources.TryGetValue(key, out object value))
            {
                return (string)value;
            }
            throw new KeyNotFoundException($"String {key} not found in resource dictionary");
        }


        private DataTemplate BuildSessionTemplate()
        {
            var template = new DataTemplate(() =>
                new Border
                {
                    StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10), StrokeThickness = 0 },

#if !WINDOWS
                    // Workaround for https://github.com/dotnet/maui/issues/9540 and https://github.com/dotnet/maui/issues/8870
                    Content = new SwipeView
                    {
                        LeftItems = new SwipeItems
                        {
                            new SwipeItem
                            {
                                Text = "Neues Fenster",
                                IconImageSource = new FontImageSource { FontFamily = "FA-6-Solid-900", Glyph= GetStringFromResource("IconUpRightFromSquare") }
                            }
                            .AppThemeColorBinding(SwipeItem.BackgroundColorProperty, Colors.LightGreen, Colors.DarkGreen)
                            .BindCommand( path: nameof(SessionsPageViewModel.OpenDetailsPageInNewWindowCommand), source: _viewModel, parameterPath: Binding.SelfPath )
                        },
                        RightItems = new SwipeItems
                        {
                             new SwipeItem
                            {
                                Text = "Favorit",
                                IconImageSource = new FontImageSource { FontFamily = "FA-6-Solid-900", Glyph= GetStringFromResource("IconHeart") }
                            }
                            .AppThemeColorBinding(SwipeItem.BackgroundColorProperty, Colors.MistyRose, Colors.Red)
                            .BindCommand( path: nameof(SessionsPageViewModel.FavoriteCommand), source: _viewModel, parameterPath: Binding.SelfPath ),

                            new SwipeItem
                            {
                                Text = "Anrufen",
                                IconImageSource = new FontImageSource { FontFamily = "FA-6-Solid-900", Glyph= GetStringFromResource("IconPhone") }
                            }
                            .AppThemeColorBinding(SwipeItem.BackgroundColorProperty, Colors.LightBlue, Colors.DarkBlue)
                            .BindCommand( path: nameof(SessionsPageViewModel.CallSpeakerCommand), source: _viewModel, parameterPath: nameof(Session.Speaker) )
                        },
#endif

                        Content = new Grid
                        {
                            RowDefinitions = Rows.Define
                        (
                            (NumericRows.First, 25),
                            (NumericRows.Second, Auto),
                            (NumericRows.Third, 60)
                        ),
                            ColumnDefinitions = Columns.Define
                        (
                            (NumericCols.First, 5),
                            (NumericCols.Second, 150),
                            (NumericCols.Third, Star)
                        ),
                            MinimumHeightRequest = 100,

                            Children =
                        {
                            new BoxView{ Color = GetColorFromResource("Blue200Accent"), VerticalOptions = LayoutOptions.Fill }.RowSpan(3),
                            new Label().Bind(Label.TextProperty, nameof(Session.Time)).Column(NumericCols.Third),

                            new Border
                            {
                               StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(15), StrokeThickness = 0},
                               Content = new Image{ MaximumWidthRequest = 130, Aspect = Aspect.AspectFill }
                                            .Bind(Image.SourceProperty, static ( Session session) => session.Speaker.Image)
                                            .Margin(new Thickness(0,0,10,0))
                            }.RowSpan(3).Column(NumericCols.Second).Margin(5),

                            new Label().Bind(Label.TextProperty, nameof(Session.Title))
                                .Row(NumericRows.Second)
                                .Column(NumericCols.Third)
                                .FontSize(16).Font(bold: true),
                            new FlexLayout
                            {
                                AlignItems = FlexAlignItems.Start,
                                Direction = FlexDirection.Row,
                                VerticalOptions = LayoutOptions.End,
                                Wrap = FlexWrap.Wrap,
                                Children =
                                {
                                    new Label{ LineBreakMode = LineBreakMode.NoWrap }.Bind(Label.TextProperty, static ( Session session) => session.Speaker.Name, stringFormat:"{0} |" ),
                                    new Label{ LineBreakMode = LineBreakMode.NoWrap, TextColor = GetColorFromResource("Gray400") }.Bind(Label.TextProperty, static ( Session session) => session.Speaker.Company),
                                }
                            }.Row(NumericRows.Third)
                             .Column(NumericCols.Third)
                        },
                            GestureRecognizers =
                        {
                            new TapGestureRecognizer().BindCommand( path: nameof(SessionsPageViewModel.NavigateToDetailsPageCommand), source: _viewModel, parameterPath: Binding.SelfPath )
                        }
                        }
                    .ContextMenu(BuildSpeakerContextFlyout())
#if !WINDOWS
                    }
#endif
                }
                .AppThemeColorBinding(BackgroundColorProperty, Colors.White, GetColorFromResource("Gray600"))
                .Margin(5)
                .Padding(0)
                .ToolTip("Kontextmenü über Rechtsklick öffnen")
            );
            return template;
        }

        private FlyoutBase BuildSpeakerContextFlyout()
        {
            var flyout = new MenuFlyout
            {
                {
                    new MenuFlyoutItem
                    {
                        Text = "Favorit",
                        IconImageSource = new FontImageSource { FontFamily = "FA-6-Solid-900", Glyph = GetStringFromResource("IconHeart"), Color = Colors.Red }
                    }.BindCommand(path: nameof(SessionsPageViewModel.FavoriteCommand), source: _viewModel, parameterPath: Binding.SelfPath)
                },
                {
                    new MenuFlyoutItem
                    {
                        Text = "In neuem Fenster öffnen",
                        IconImageSource = new FontImageSource
                        {
                            FontFamily = "FA-6-Solid-900",
                            Glyph = GetStringFromResource("IconUpRightFromSquare")
                        }.AppThemeColorBinding(FontImageSource.ColorProperty, Colors.Black, Colors.White)
                    }.BindCommand(path: nameof(SessionsPageViewModel.OpenDetailsPageInNewWindowCommand), source: _viewModel, parameterPath: Binding.SelfPath)
                },
                new MenuFlyoutSeparator(),
            };

            var callSpeakerMenuFlyoutSubItem = new MenuFlyoutSubItem
            {
                Text = "Sprecher anrufen",
                IconImageSource = new FontImageSource
                {
                    FontFamily = "FA-6-Solid-900",
                    Glyph = GetStringFromResource("IconPhone")
                }.AppThemeColorBinding(FontImageSource.ColorProperty, Colors.Black, Colors.White)
            };

            callSpeakerMenuFlyoutSubItem.Add(
                new MenuFlyoutItem
                {
                    Text = "Geschäftlich"
                }
                .BindCommand(path: nameof(SessionsPageViewModel.CallSpeakerBusinessCommand), source: _viewModel, parameterPath: nameof(Session.Speaker))
                );


            callSpeakerMenuFlyoutSubItem.Add(
                new MenuFlyoutItem
                {
                    Text = "Privat"
                }
                .BindCommand(path: nameof(SessionsPageViewModel.CallSpeakerPrivateCommand), source: _viewModel, parameterPath: nameof(Session.Speaker))
                );


            flyout.Add(callSpeakerMenuFlyoutSubItem);

            return flyout;
        }

        enum Row { Header, Content }

        enum NumericRows { First, Second, Third }
        enum NumericCols { First, Second, Third }


    }
}
