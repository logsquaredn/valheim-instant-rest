.PHONY: build format package

build:
	@if [ ! -f "lib/assembly_valheim.dll" ]; then \
		echo "Error: lib/assembly_valheim.dll not found!"; \
		echo "Please copy it from: Valheim/valheim_Data/Managed/assembly_valheim.dll"; \
		exit 1; \
	fi
	dotnet build InstantRest.sln && echo "\nCopy bin/Debug/net462/InstantRest.dll to your Valheim/BepInEx/plugins/ folder"

format:
	dotnet format

package:
	@mkdir -p pkg
	@if [ ! -f "bin/Debug/net462/InstantRest.dll" ]; then \
		echo "Error: bin/Debug/net462/InstantRest.dll not found! Run 'make build' first."; \
		exit 1; \
	fi
	@cd pkg && rm -f InstantRest.zip
	@zip -j pkg/InstantRest.zip README.md bin/Debug/net462/InstantRest.dll manifest.json icon.png
