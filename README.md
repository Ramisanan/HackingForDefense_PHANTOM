# PHANTOM Unity MVP

This project is a Unity proof of concept for the Hacking for Defense final MVP. It connects a medical VR vaccine scene with the PHANTOM Library so the simulation can produce procedure-specific haptic feedback values.

The goal is to show that medical contact in Unity can be connected to structured haptic data instead of using random or hardcoded feedback.

## What This MVP Does

When the patient body is touched in the Unity vaccine scene, the system:

1. Detects contact with the patient body
2. Loads tissue-layer data from the PHANTOM Library CSV
3. Identifies the active procedure
4. Displays the current tissue layer
5. Simulates expected force and vibration values
6. Triggers a pop event when the skin layer is breached
7. Prints the haptic feedback result in the Unity Console

Example Console output:

```text
Procedure: VAX01
Depth: 1.5 mm
Layer: Skin
Force: 4.01 N
Vibration: 291.7 Hz
Feel: Sharp skin puncture
POP EVENT: Skin breached
