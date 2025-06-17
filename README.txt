# 📱 PapAR — Android AR Maintenance App

**PapAR** is an AR-based maintenance aid built with Unity and AR Foundation. It overlays digital visualizations onto machinery using ARCore-compatible Android devices. This version allows you to tap to place a 3D model (e.g., a paper machine) in real-world space, and control its scale via a UI slider.

---

## 🚀 Features

- ✅ Tap-to-place on detected surfaces (AR plane detection)
- ✅ Accurate ARCore-based anchoring
- ✅ Only one model placed at a time (auto repositioning on tap)
- ✅ Real-time scale adjustment via UI slider

---

## 📱 Android Requirements

- Device must support **ARCore** (e.g., Pixel 7a, Samsung Galaxy S10+ and up)
- Android 10+ recommended
- Camera permissions required

---

## 🛠️ How to Build & Run (Android)

### ✅ Unity Setup
- Unity Editor 6.x LTS or 2023.3+
- Install **Android Build Support**
- Packages used:
  - `AR Foundation`
  - `ARCore XR Plugin`
  - `XR Plugin Management`

### ⚙️ Player Settings

In `Edit → Project Settings → Player (Android)`:
- Set **Minimum API Level** to `Android 10 (API Level 29)`
- Under **XR Plug-in Management → Android**, enable ✅ `ARCore`
- In **Other Settings → Graphics API**, remove ❌ `Vulkan` (keep `OpenGLES3`)

---

## 🧪 Testing on Device

1. Enable **Developer Options** and **USB Debugging** on your Android device
2. Connect via USB
3. Click **Build and Run** in Unity Build Profiles window
4. Tap a surface to place the 3D model
5. Use the UI slider to scale it in real time

---

## 🧰 Folder Structure

Assets/
├── Scripts/
│ └── TapToPlaceWithScale.cs
├── Prefabs/
│ └── [Your machine model here]
├── UI/
│ └── Slider (scale control)

