Dies ist das Beispielprojekt zu meinem Vortrag auf der [Basta Spring 2023](https://basta.net/user-interface/durchstarten-mit-net-maui/).

Zum ausführen des Quellcodes wird [Visual Studio 2022 17.4.5](https://visualstudio.microsoft.com/de/vs/) 
inklusive des Workloads Mobile Entwicklung mit .NET benötigt.

Die Anwendung demonstriert folgendes:

- Navigation mit der .NET MAUI-Shell
- Darstellung von Icons über Icon-Fonts
- Darstellung von Listen mit dem CollectionView
- Darstellung von Schatten und abgerundeten Ecken über die Elemente Shadow und Border
- Aufruf von plattformspzeifischem Code über Präprozessoranweisungen, partielle Klassen und Dependency Injection
- MVVM mit dem CommunityToolkit
- Einfacher Einsatz des .NET MAUI Community Toolkit (Converter, Extensions und Toasts)
- Einsatz von [C# Markup aus dem .NET MAUI Community Toolkit](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/maui/markup/markup)
- Einsatz von Styles
- Unterstützung des Darkmodes
- Positionieren des Anwendungsfensters (nur unter Windows)
- Anzeige von Anwedungsmenüs (nur unter Windows und macOS)
- Kontextmenüs (nur unter Windows und macOS)
- Tooltips (nur unter Windows und macOS)
- Pointer-Events (nur unter Windows und macOS)
- Primärer und sekundärer Klick (rechtsklick) (nur unter Windows und macOS)
- Darstellung von Karten (nicht unter Windows, da dies unter .NET MAUI 7 dort nicht unterstüzt wird)

Unter Android muss für die Darstellung von Karten ein API-Key in der Datei `AndroidManifest.xml` hinterlegt werden.

## Weitere Informationen zu .NET MAUI
Weitere Informationen zu .NET MAUI gibt es in meinem Buch [Cross-Plattform-Apps mit .NET MAUI entwickeln](https://www.andrekraemer.de/maui-buch)
(ISBN: 978-3-446-47261-7), erschienen im Dezember 2022 beim Carl Hanser Verlag.

![Buchcover: Cross-Plattform-Apps mit .NET MAUI entwickeln](https://github.com/AndreKraemer/maui-buch-2022/raw/main/images/maui-buch.jpg)

## Fragen und Kontakt

Twitter: https://twitter.com/codemurai
LinkedIn: https://linkedin.com/in/andrekraemer