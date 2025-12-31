# Valheim Instant Rest

A Valheim mod that causes the player to instantly obtain rested bonus

## current features
1. Instant rest

## prereq

1. Valheim
2. BepInEx
3. .NET SDK

## setup

From `Valheim/valheim_Data/Managed/`, copy:
- `assembly_valheim.dll`

Create a `lib` folder in this project and place both files there:
```bash
mkdir lib
# Copy assembly_valheim.dll to lib/
```

## build

```bash
make build
```

## install

Copy `bin/Debug/net46/InstantRest.dll` to your Valheim BepInEx plugins folder

## Thunderstore package

```bash
make package
```

