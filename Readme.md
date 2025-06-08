[![Build Status](https://codefirst.iut.uca.fr/api/badges/2025_SAE_1A/SAE_1A_G7_JABBOUR_HALILOU_PERRIER_Memory/status.svg?ref=refs/heads/master)](https://codefirst.iut.uca.fr/2025_SAE_1A/SAE_1A_G7_JABBOUR_HALILOU_PERRIER_Memory)
[![Quality Gate Status](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=alert_status&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Code Smells](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=code_smells&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Duplicated Lines (%)](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=duplicated_lines_density&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Lines of Code](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=ncloc&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Maintainability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=sqale_rating&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Reliability Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=reliability_rating&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Security Rating](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=security_rating&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)
[![Vulnerabilities](https://codefirst.iut.uca.fr/sonar/api/project_badges/measure?project=MemoryDotnet&metric=vulnerabilities&token=57cbc68b7ab086fb472b8eee00b1e9f020daa26c)](https://codefirst.iut.uca.fr/sonar/dashboard?id=MemoryDotnet)


# 🧠 Memory Game 

A grid filled with face-down card pairs awaits your discovery.  
Use your memory to match them up!  
⚠️ The larger the grid, the harder the challenge!

---

## 🚀 Installation

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed
- A terminal (PowerShell, bash, zsh...)

## Installation Steps

1. **Clone the repository**

```sh
git clone https://codefirst.iut.uca.fr/git/2025_SAE_1A/SAE_1A_G7_JABBOUR_HALILOU_PERRIER_Memory.git
cd SAE_1A_G7_JABBOUR_HALILOU_PERRIER_Memory
```

2. **Restore dependencies**

```sh
dotnet restore
```

3. **Build the project**

```sh
dotnet build src/Memory/Memory.sln
```
4. **Publish the projet**

```sh
dotnet publish -f net9.0-windows10.0.19041.0 -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=false -p:UseMonoRuntime=false -p:WindowsPackageType=None
```

5. **Run the application**

```sh
dotnet run --project src/Memory/Memory.sln
```
---

> 🛠 Make sure .NET MAUI is properly installed and configured on your system.

---

## 🛠️ Technologies Used

* 💻 **C#**
* 🧱 **.NET MAUI**
* 🎨 **XAML**
* 🔧 **Git**

---

## ✨ Features

* 💾 **Save System**
  Records each player’s move count and adds it to the leaderboard when the game ends.

* 👥 **One or Two Players**
  Play solo or challenge a friend.

* 🧩 **Custom Grid Sizes**
  Choose the size of the board to adjust the difficulty.

* 🎭 **Themes & Custom Cards**
  Pick from predefined themes or import your own card designs.

* 📊 **Leaderboard**
  Track the fewest moves per grid size. Filter by name to find your personal best scores.

---

## 👨‍💻 Authors

* 🧑‍💻 HALILOU Sami
* 👨‍💻 JABBOUR Ghassan
* 👨‍💻 PERRIER Mylan

---

## Acknowledgements

* 🧑‍💻 PICHOT-MOISE Matheo

---

## 🐞 Known Issues

* ⚙️ **Doxygen**: The documentation is present throughout the codebase, but there are issues generating Doxygen output.
* 📉 **Sonar**: Code coverage is below 95%, and there are still more than 5 code smells to address.

---

## 🗂️ Categories

* 🎮 **Game**
* 🧠 **Puzzle**
* 👨‍🏫 **Educational**
* 🧪 **Project SAE**
* 🛠️ **Student Project**

