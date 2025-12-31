.PHONY: build format

build:
	@if [ ! -f "lib/assembly_valheim.dll" ]; then \
		echo "Error: lib/assembly_valheim.dll not found!"; \
		echo "Please copy it from: Valheim/valheim_Data/Managed/assembly_valheim.dll"; \
		exit 1; \
	fi
	dotnet build InstantRest.sln && echo "\nCopy bin/Debug/net462/instantrest.dll to your Valheim/BepInEx/plugins/ folder"

format:
	dotnet format
