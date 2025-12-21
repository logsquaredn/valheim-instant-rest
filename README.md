# Dillos Valheim Mod

A Valheim mod for Dillos

## current features
1. Instant rest

## prereq

1. Valheim
2. BepInEx
3. Jotunn
3. .NET SDK

## setup

Download Jotunn and copy `Jotunn.dll` to `Valheim/BepInEx/plugins/`

From `Valheim/valheim_Data/Managed/`, copy:
- `assembly_valheim.dll`

Create a `lib` folder in this project and place both files there:
```bash
mkdir lib
# Copy assembly_valheim.dll to lib/
# Copy Jotunn.dll to lib/
```

## build

```bash
make build
```

## install

Copy `bin/Debug/net46/ValheimMod.dll` to your Valheim BepInEx plugins folder
