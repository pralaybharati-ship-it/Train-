# RUNAWAY TRAIN — GitHub Pages

This repository builds the Unity game as WebGL and deploys it to GitHub Pages automatically.

## One-time GitHub setup

1. Create a repository, for example `runaway-train`.
2. Upload/extract the repository contents into the repo root.
3. In GitHub: Settings → Pages → Source: **GitHub Actions**.
4. Add Unity activation secrets under Settings → Secrets and variables → Actions:
   - `UNITY_LICENSE`
   - `UNITY_EMAIL`
   - `UNITY_PASSWORD`
5. Push to the `main` branch.
6. Open Actions and wait for **RUNAWAY TRAIN — WebGL → GitHub Pages** to finish.
7. The deployment job shows the exact Pages URL.

## URL

For a repository named `runaway-train`, GitHub Pages normally uses:

`https://YOUR-USERNAME.github.io/runaway-train/`

Replace `YOUR-USERNAME` with the GitHub account name.

## Playing

Open the Pages URL in a modern browser. The Unity WebGL game loads in the page.

Desktop controls:
- A / Left Arrow: move left
- D / Right Arrow: move right
- Space / W / Up Arrow: jump

The game's JSON save system persists browser-side through Unity's persistent data storage, so progress can continue on the same browser/device.

## Important

GitHub Pages hosts the WebGL build. It does not run the Unity Editor or Android APK.

The workflow uses GameCI's Unity Builder to create the WebGL build and GitHub's Pages deployment actions to publish it.
