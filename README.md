# Migrant

Open-source 3D multiplayer game with survial, combat and exploration elements.



## 🎮 About
[I will fill this out later, I want have some substance first]

## 🚀 Getting Started

### Prerequisites
- Unity [2022.3.20f1 LTS]
- Git with Git LFS installed
- [List any other requirements]

### Installation
1. Clone the repository
```bash
git clone git@github.com:Leipip/Migrant.git
``` 
2. cd Migrant
3. Open the project in Unity Hub
4. Open the Main scene in Assets/_Project/Scenes/Main.unity
5. Press Play to test locally!   

## Testing Multiplayer Locally

1. Press Play in Unity Editor
2. Click "Host"
3. Build the game (Ctrl+B)
4. Run the .exe and click "Client"
5. Enter "localhost"

## 🛠️ Tech Stack

* Engine: Unity [2022.3.20f1 LTS]
* Networking: Mirror Networking
* Backend: Supabase
* CI/CD: GitHub Actions
* Hosting: Oracle Cloud (planned)


## 📁 Project Structure

Assets/_Project/ - Main game code and assets\
Assets/_Project/Scripts/ - All C# scripts\
Assets/_Project/Prefabs/ - Reusable game objects

##  📋 Roadmap
- [ ] Small scale open world environment & player creation(3rd person, with basic controls)
- [ ] Simple multiplayer setup with Mirror Networking for a Client-Server architecture
- [ ] Simple meele combat system [Mordhau inspired] [Bunch of stuff happening here: proper character models ,animations ,combat logic and more networking items to implement]
- [ ] Persistent servers
- [ ] Account system
- [ ] Make the combat system better and add mobs[plus all the elements needed to make them function properly as far as collsions, movement patterns, spawn rates, player detection, ai mob logic, reosurce clean up, etc..]
- [ ] More to come whenever here is reached..
