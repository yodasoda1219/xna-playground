ifndef PYTHON_COMMAND
	PYTHON_COMMAND := python
endif
all: native-binaries managed-projects submodules
submodules:
	@echo "Syncing submodules..."
	@git submodule update --init --recursive
managed-projects: submodules
	@echo "Compiling managed code..."
	@dotnet build /property:GenerateFullPaths=true /consoleloggerparameters:NoSummary
native-binaries: managed-projects
	@echo "Copying native binaries..."
	@$(PYTHON_COMMAND) copy-binaries.py