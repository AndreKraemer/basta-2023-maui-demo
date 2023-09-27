Dies ist das Beispielprojekt zu meinem Vortrag auf der [Basta 2023](https://basta.net/net-framework-c/net-maui-c-sharp/).

Zum ausführen des Quellcodes wird [Visual Studio 2022 17.7.4](https://visualstudio.microsoft.com/de/vs/) 
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
- Darstellung von Karten (unter Windows über das MAUI Community Toolkit, da Karten nativ unter .NET MAUI 7 in WinUI nicht nativ unterstüzt werden)
- COM-Interop (Word-Automatisierung) unter Windows

Unter Android muss für die Darstellung von Karten ein API-Key in der Datei `AndroidManifest.xml` hinterlegt werden. Für Windows muss ein BING-MAPS-Key in der Datei startup.cs eingefügt werden.

## Weitere Informationen zu .NET MAUI
Weitere Informationen zu .NET MAUI gibt es in meinem Buch [Cross-Plattform-Apps mit .NET MAUI entwickeln](https://www.andrekraemer.de/maui-buch)
(ISBN: 978-3-446-47261-7), erschienen im Dezember 2022 beim Carl Hanser Verlag.

![Buchcover: Cross-Plattform-Apps mit .NET MAUI entwickeln](https://github.com/AndreKraemer/maui-buch-2022/raw/main/images/maui-buch.jpg)

## Fragen und Kontakt

Twitter: https://twitter.com/codemurai
LinkedIn: https://linkedin.com/in/andrekraemer
