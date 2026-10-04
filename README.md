# RUNAWAY TRAIN — PLAYABLE UNITY PROTOTYPE

A playable offline 3D Unity prototype.

Developer: PRALAY
Game: RUNAWAY TRAIN

## Included
- Playable third-person runner
- Procedural train roof/track environment
- Keyboard controls + simple mobile-ready input hooks
- Obstacles
- Coins
- Checkpoints
- Health
- Score
- Persistent JSON save
- Continue / New Game
- Pause / Resume
- Game Over
- Runtime UI
- No external art assets required

## Controls
A/D or Left/Right = move
W/Space = jump
P/Escape = pause

## Setup
Open the project in Unity Hub. Open:
Assets/RunawayTrain/Scenes/RunawayTrain.unity

Press Play.

If your Unity version reports package-version warnings, Unity can regenerate compatible packages; the project uses standard built-in Unity APIs.

Save file:
Application.persistentDataPath/runaway_train_save.json


## GitHub deployment
This repository is structured for GitHub source hosting and GitHub Actions Android builds.
See `GITHUB_DEPLOY.md`.

### Repository root
- `Assets/` — game source
- `Packages/` — Unity packages
- `ProjectSettings/` — Unity project/build settings
- `.github/workflows/` — Android CI


## 🌐 Play on GitHub Pages

This repository now includes automatic Unity WebGL deployment.

Workflow:
`.github/workflows/deploy-webgl.yml`

After GitHub Pages is configured and the Unity Actions secrets are added, every push to `main` builds the WebGL game and publishes it to GitHub Pages.

See `GITHUB_PAGES.md`.
