# Zelda Game Project

Ett 2D spel inspirerat av The Legend of Zelda, byggt med MonoGame och C#.

![Game Screenshot](https://github.com/user-attachments/assets/d10b8e4f-b0ab-42bc-8b04-8882f4cc7e9a)

## Om Projektet

Detta projekt är ett tile-baserat spel där spelaren ska hitta en nyckel och ta sig till dörren samtidigt som de undviker eller besegrar skelettfiender. Spelet är byggt med MonoGame framework och använder tile-baserad kollisionsdetektion.

## Funktioner

- Tile-baserad rörelse och världsgenerering från textfil
- Spelare med svärdsattacker
- Fiendesystem med AI
- Nyckel och dörr-mekanik
- Liv-system med invulnerabilitet
- Start- och slutskärmar

## Kontroller

- **Piltangenter**: Rörelse
- **Mellanslag**: Attackera
- **Enter**: Starta spelet
- **Escape**: Avsluta

## Installation & Körning

1. Klona repot
2. Öppna i Visual Studio
3. Se till att MonoGame Framework är installerat
4. Bygg och kör projektet

## Teknologier

- C#
- MonoGame Framework
- Tile-based game design

## Vad Jag Lärt Mig

Under detta projekt har jag fördjupat mina kunskaper inom:

- **Game loop och state management**: Implementerat olika game states (Menu, GamePlay, GameEnded) och lärt mig hantera övergångar mellan dessa
- **Kollisionsdetektion**: Arbetat med Rectangle-baserad kollision för spelare, fiender och projektiler
- **Tile-system**: Skapat ett system för att ladda och rendera världar från textfiler
- **Object-Oriented Programming**: Strukturerat kod i klasser med tydligt ansvar (Player, Enemy, TileMap, etc.)
- **Game timing**: Implementerat invulnerabilitets-timer och projektilrörelse baserat på GameTime
- **Input handling**: Hantering av keyboard input för både kontinuerlig och event-baserad input

## Framtida Förbättringar

- Lägg till fler attackriktningar
- Implementera animationer
- Ljud och musik
- Flera nivåer
- Bättre UI för liv-visning
