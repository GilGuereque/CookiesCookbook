# Cookies Cookbook

> This application lets the user create and save cookie recipes. The user can select the ingredients that will be included in the recipe from a list. The recipe is then saved to a text file along with recipes that have been created before. 
The text file might be either in a *.txt or a *.json format, depending on the setting defined in a program.

---

## Table of Contents

1. [Description](#description)  
2. [Demo](#demo)  
3. [Features](#features)  
4. [Tech Stack](#tech-stack)  
5. [Getting Started](#getting-started)  
   - [Prerequisites](#prerequisites)  
   - [Installation](#installation)  
   - [Configuration](#configuration)  
6. [Usage](#usage)  
7. [Running Tests](#running-tests)  
8. [Deployment](#deployment)  
9. [Contributing](#contributing)  
10. [License](#license)  
11. [Authors](#authors)  
12. [Acknowledgements](#acknowledgements)

---

## Description

<!-- Describe what your project does and why it exists. -->

- **Problem**: How to serialize data from an object and save it to a file using OOP  
- **Solution**: Using OOP & serialization methods to save user's recipes into text files
- **Audience**: Folks interested in C#

---

## Demo

<!-- Showcase images, GIFs, or links to a running demo -->

![Project demo screenshot](path/to/screenshot.png)

---

## Features

- Feature 1: Display list of ingredients for a user to create a recipe from
- Feature 2: Select ingredients and save as a recipe to be printed for the user
- Feature 3: Save corresponding recipe to a text file on the user's local machine, which the application can still read from

---

## Tech Stack

- **Language:** C#

---

## Getting Started

### Prerequisites

List any software or accounts needed before installation:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)  


### Installation

```bash
# 1. Clone the repo
git clone https://github.com/GilGuereque/CookiesCookbook
cd <repository>

# 2. Install dependencies
# For .NET backend
dotnet restore

# For frontend (if any)
npm install
