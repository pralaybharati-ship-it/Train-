# GitHub deployment

## 1. Create repository
Create a GitHub repository named `runaway-train`.

## 2. Upload
Upload the contents of this folder to the repository root.

Do NOT upload the ZIP itself as the repository project.

## 3. Unity source
The repository contains:
- Assets/
- Packages/
- ProjectSettings/
- .github/

This is the Unity source project.

## 4. Android build
The workflow is:
`.github/workflows/unity-android.yml`

It builds an Android APK and publishes it as a GitHub Actions artifact.

## 5. Required GitHub Secrets
For GameCI, configure:
- UNITY_LICENSE
- UNITY_EMAIL
- UNITY_PASSWORD

Use a Unity license suitable for your account/project.

## 6. Run build
GitHub:
Actions -> Build Runaway Train Android -> Run workflow

The finished APK appears under the workflow run's Artifacts.

## Important
GitHub Pages is not an Android APK runtime. It hosts web content.
For Android, GitHub Actions is the correct CI/build path.
